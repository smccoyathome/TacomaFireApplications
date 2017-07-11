/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("TFDIncident.frmFireReport", [ "files/text!views/TFDIncident.frmFireReport.html", "files/css!views/TFDIncident.frmFireReport.css"],
    (htmlTemplate) => {
    return class frmFireReport extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("cmdHelp_Click",this.cmdHelp_Click);
this.bind("cmdSave_Click",this.cmdSave_Click);
this.bind("tabFire_Selecting",this.tabFire_Selecting);
this.bind("txtTotalSqFootage_TextChanged",this.txtTotalSqFootage_TextChanged);
this.bind("txtTotalSqFootage_Enter",this.txtTotalSqFootage_Enter);
this.bind("txtTotalSqFootage_Leave",this.txtTotalSqFootage_Leave);
this.bind("cboGeneralPropertyUse_SelectionChangeCommitted",this.cboGeneralPropertyUse_SelectionChangeCommitted);
this.bind("cboGeneralPropertyUse_Enter",this.cboGeneralPropertyUse_Enter);
this.bind("cboGeneralPropertyUse_Leave",this.cboGeneralPropertyUse_Leave);
this.bind("txtNumberOfStories_TextChanged",this.txtNumberOfStories_TextChanged);
this.bind("txtNumberOfUnits_TextChanged",this.txtNumberOfUnits_TextChanged);
this.bind("cboSpecificPropertyUse_SelectionChangeCommitted",this.cboSpecificPropertyUse_SelectionChangeCommitted);
this.bind("cboSpecificPropertyUse_Enter",this.cboSpecificPropertyUse_Enter);
this.bind("txtNumberOfOccupants_TextChanged",this.txtNumberOfOccupants_TextChanged);
this.bind("cboBuildingStatus_SelectionChangeCommitted",this.cboBuildingStatus_SelectionChangeCommitted);
this.bind("cboBuildingStatus_Leave",this.cboBuildingStatus_Leave);
this.bind("txtNumberOfBusinesses_TextChanged",this.txtNumberOfBusinesses_TextChanged);
this.bind("txtPropValue_TextChanged",this.txtPropValue_TextChanged);
this.bind("txtPropValue_Enter",this.txtPropValue_Enter);
this.bind("cboConstructionType_SelectionChangeCommitted",this.cboConstructionType_SelectionChangeCommitted);
this.bind("cboConstructionType_Leave",this.cboConstructionType_Leave);
this.bind("optAlarmType_CheckedChanged",this.optAlarmType_CheckedChanged);
this.bind("chkAlarmOperation_CheckStateChanged",this.chkAlarmOperation_CheckStateChanged);
this.bind("cboAlarmType_SelectionChangeCommitted",this.cboAlarmType_SelectionChangeCommitted);
this.bind("cboAlarmType_Leave",this.cboAlarmType_Leave);
this.bind("cboInitiatingDevice_SelectionChangeCommitted",this.cboInitiatingDevice_SelectionChangeCommitted);
this.bind("cboInitiatingDevice_Leave",this.cboInitiatingDevice_Leave);
this.bind("cboEffectiveness_SelectionChangeCommitted",this.cboEffectiveness_SelectionChangeCommitted);
this.bind("cboEffectiveness_Leave",this.cboEffectiveness_Leave);
this.bind("optExtinguish_CheckedChanged",this.optExtinguish_CheckedChanged);
this.bind("chkExtOperation_CheckStateChanged",this.chkExtOperation_CheckStateChanged);
this.bind("cboSysType_SelectionChangeCommitted",this.cboSysType_SelectionChangeCommitted);
this.bind("cboSysType_Leave",this.cboSysType_Leave);
this.bind("cboExtEffectiveness_SelectionChangeCommitted",this.cboExtEffectiveness_SelectionChangeCommitted);
this.bind("cmdCancelExit_Click",this.cmdCancelExit_Click);
this.bind("cboMobilePropType_SelectionChangeCommitted",this.cboMobilePropType_SelectionChangeCommitted);
this.bind("cboMobilePropType_Leave",this.cboMobilePropType_Leave);
this.bind("txtMobilePropValue_Leave",this.txtMobilePropValue_Leave);
this.bind("cboMobileMake_SelectionChangeCommitted",this.cboMobileMake_SelectionChangeCommitted);
this.bind("txtVehicleMake_TextChanged",this.txtVehicleMake_TextChanged);
this.bind("txtVehicleYear_Leave",this.txtVehicleYear_Leave);
this.bind("cboAreaOfOrigin_SelectionChangeCommitted",this.cboAreaOfOrigin_SelectionChangeCommitted);
this.bind("cboAreaOfOrigin_Leave",this.cboAreaOfOrigin_Leave);
this.bind("cboHeatSource_SelectionChangeCommitted",this.cboHeatSource_SelectionChangeCommitted);
this.bind("cboHeatSource_Leave",this.cboHeatSource_Leave);
this.bind("cboFirstItemIgnited_SelectionChangeCommitted",this.cboFirstItemIgnited_SelectionChangeCommitted);
this.bind("cboFirstItemIgnited_Leave",this.cboFirstItemIgnited_Leave);
this.bind("cboGenCauseOfIgnition_SelectionChangeCommitted",this.cboGenCauseOfIgnition_SelectionChangeCommitted);
this.bind("cboGenCauseOfIgnition_Leave",this.cboGenCauseOfIgnition_Leave);
this.bind("cboSpecCauseOfIgnition_SelectionChangeCommitted",this.cboSpecCauseOfIgnition_SelectionChangeCommitted);
this.bind("cboSpecCauseOfIgnition_Leave",this.cboSpecCauseOfIgnition_Leave);
this.bind("lstHumanContribFactors_SelectedIndexChanged",this.lstHumanContribFactors_SelectedIndexChanged);
this.bind("txtHFAge_TextChanged",this.txtHFAge_TextChanged);
this.bind("txtFloorOfOrigin_TextChanged",this.txtFloorOfOrigin_TextChanged);
this.bind("txtFloorOfOrigin_Leave",this.txtFloorOfOrigin_Leave);
this.bind("optFloor_CheckStateChanged",this.optFloor_CheckStateChanged);
this.bind("cboBurnDamage_SelectionChangeCommitted",this.cboBurnDamage_SelectionChangeCommitted);
this.bind("cboBurnDamage_Leave",this.cboBurnDamage_Leave);
this.bind("cboSmokeDamage_SelectionChangeCommitted",this.cboSmokeDamage_SelectionChangeCommitted);
this.bind("cboSmokeDamage_Leave",this.cboSmokeDamage_Leave);
this.bind("chkExposures_CheckStateChanged",this.chkExposures_CheckStateChanged);
this.bind("chkMobileInvolved_CheckStateChanged",this.chkMobileInvolved_CheckStateChanged);
this.bind("txtSqFtBurned_TextChanged",this.txtSqFtBurned_TextChanged);
this.bind("txtSqFtBurned_Leave",this.txtSqFtBurned_Leave);
this.bind("txtSqFtSmokeDamage_TextChanged",this.txtSqFtSmokeDamage_TextChanged);
this.bind("txtSqFtSmokeDamage_Leave",this.txtSqFtSmokeDamage_Leave);
this.bind("txtPropLoss_TextChanged",this.txtPropLoss_TextChanged);
this.bind("txtContentLoss_TextChanged",this.txtContentLoss_TextChanged);
this.bind("optOSType_CheckedChanged",this.optOSType_CheckedChanged);
this.bind("cboOSHeatSource_SelectionChangeCommitted",this.cboOSHeatSource_SelectionChangeCommitted);
this.bind("cboOSHeatSource_Leave",this.cboOSHeatSource_Leave);
this.bind("cboOSCauseOfIgnition_SelectionChangeCommitted",this.cboOSCauseOfIgnition_SelectionChangeCommitted);
this.bind("cboOSCauseOfIgnition_Leave",this.cboOSCauseOfIgnition_Leave);
this.bind("cboOSSpecCauseOfIgnition_SelectionChangeCommitted",this.cboOSSpecCauseOfIgnition_SelectionChangeCommitted);
this.bind("cboOSSpecCauseOfIgnition_Leave",this.cboOSSpecCauseOfIgnition_Leave);
this.bind("txtOSLoss_Leave",this.txtOSLoss_Leave);
this.bind("txtOSAreaAffected_Leave",this.txtOSAreaAffected_Leave);
this.bind("cboOSAreaUnits_SelectionChangeCommitted",this.cboOSAreaUnits_SelectionChangeCommitted);
this.bind("cboOSAreaUnits_Leave",this.cboOSAreaUnits_Leave);
this.bind("cboOSMaterialInvolved_SelectionChangeCommitted",this.cboOSMaterialInvolved_SelectionChangeCommitted);
this.bind("cboOSMaterialInvolved_Leave",this.cboOSMaterialInvolved_Leave);
this.bind("cboNarrList_SelectionChangeCommitted",this.cboNarrList_SelectionChangeCommitted);
this.bind("cmdAddNarration_Click",this.cmdAddNarration_Click);
this.bind("cboNameList_SelectionChangeCommitted",this.cboNameList_SelectionChangeCommitted);
this.bind("cboNameList_Leave",this.cboNameList_Leave);
this.bind("txtFirstName_TextChanged",this.txtFirstName_TextChanged);
this.bind("txtFirstName_Leave",this.txtFirstName_Leave);
this.bind("txtLastName_TextChanged",this.txtLastName_TextChanged);
this.bind("txtLastName_Leave",this.txtLastName_Leave);
this.bind("txtMI_TextChanged",this.txtMI_TextChanged);
this.bind("txtBusinessName_TextChanged",this.txtBusinessName_TextChanged);
this.bind("txtBusinessName_Leave",this.txtBusinessName_Leave);
this.bind("txtHouseNumber_TextChanged",this.txtHouseNumber_TextChanged);
this.bind("cboPrefix_SelectionChangeCommitted",this.cboPrefix_SelectionChangeCommitted);
this.bind("cboPrefix_Leave",this.cboPrefix_Leave);
this.bind("txtStreetName_TextChanged",this.txtStreetName_TextChanged);
this.bind("cboStreetType_SelectionChangeCommitted",this.cboStreetType_SelectionChangeCommitted);
this.bind("cboStreetType_Leave",this.cboStreetType_Leave);
this.bind("cboSuffix_SelectionChangeCommitted",this.cboSuffix_SelectionChangeCommitted);
this.bind("cboSuffix_Leave",this.cboSuffix_Leave);
this.bind("txtCity_TextChanged",this.txtCity_TextChanged);
this.bind("cboState_SelectionChangeCommitted",this.cboState_SelectionChangeCommitted);
this.bind("cboState_Leave",this.cboState_Leave);
this.bind("txtZipcode_TextChanged",this.txtZipcode_TextChanged);
this.bind("cboRole_SelectionChangeCommitted",this.cboRole_SelectionChangeCommitted);
this.bind("cboRole_Leave",this.cboRole_Leave);
this.bind("txtHomePhone_TextChanged",this.txtHomePhone_TextChanged);
this.bind("txtBirthdate_TextChanged",this.txtBirthdate_TextChanged);
this.bind("optGender_CheckedChanged",this.optGender_CheckedChanged);
this.bind("txtWorkPhone_TextChanged",this.txtWorkPhone_TextChanged);
this.bind("txtWorkPlace_TextChanged",this.txtWorkPlace_TextChanged);
this.bind("cboRace_SelectionChangeCommitted",this.cboRace_SelectionChangeCommitted);
this.bind("cboRace_Leave",this.cboRace_Leave);
this.bind("optEthnicity_CheckedChanged",this.optEthnicity_CheckedChanged);
this.bind("cmdMoreNames_Click",this.cmdMoreNames_Click);
this.bind("txtXHouseNumber_TextChanged",this.txtXHouseNumber_TextChanged);
this.bind("cboXPrefix_SelectionChangeCommitted",this.cboXPrefix_SelectionChangeCommitted);
this.bind("cboXPrefix_Leave",this.cboXPrefix_Leave);
this.bind("txtXStreetName_TextChanged",this.txtXStreetName_TextChanged);
this.bind("cboXStreetType_SelectionChangeCommitted",this.cboXStreetType_SelectionChangeCommitted);
this.bind("cboXStreetType_Leave",this.cboXStreetType_Leave);
this.bind("cboXSuffix_SelectionChangeCommitted",this.cboXSuffix_SelectionChangeCommitted);
this.bind("cboXSuffix_Leave",this.cboXSuffix_Leave);
this.bind("cboCityCode_SelectionChangeCommitted",this.cboCityCode_SelectionChangeCommitted);
this.bind("cboCityCode_Leave",this.cboCityCode_Leave);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmFireReport";
            }

            public loaded() {
			
            }

        

        public frmFireReport_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmFireReport",action:"frmFireReport_Close"});
                e.preventDefault();
            }
            
        }
        public cmdHelp_Click(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdSave_Click(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public tabFire_Selecting(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtTotalSqFootage_TextChanged(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtTotalSqFootage_Enter(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtTotalSqFootage_Leave(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboGeneralPropertyUse_SelectionChangeCommitted(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboGeneralPropertyUse_Enter(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboGeneralPropertyUse_Leave(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtNumberOfStories_TextChanged(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtNumberOfUnits_TextChanged(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboSpecificPropertyUse_SelectionChangeCommitted(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboSpecificPropertyUse_Enter(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtNumberOfOccupants_TextChanged(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboBuildingStatus_SelectionChangeCommitted(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboBuildingStatus_Leave(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtNumberOfBusinesses_TextChanged(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtPropValue_TextChanged(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtPropValue_Enter(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboConstructionType_SelectionChangeCommitted(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboConstructionType_Leave(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public optAlarmType_CheckedChanged(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public chkAlarmOperation_CheckStateChanged(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboAlarmType_SelectionChangeCommitted(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboAlarmType_Leave(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboInitiatingDevice_SelectionChangeCommitted(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboInitiatingDevice_Leave(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboEffectiveness_SelectionChangeCommitted(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboEffectiveness_Leave(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public optExtinguish_CheckedChanged(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public chkExtOperation_CheckStateChanged(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboSysType_SelectionChangeCommitted(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboSysType_Leave(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboExtEffectiveness_SelectionChangeCommitted(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdCancelExit_Click(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboMobilePropType_SelectionChangeCommitted(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboMobilePropType_Leave(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtMobilePropValue_Leave(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboMobileMake_SelectionChangeCommitted(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtVehicleMake_TextChanged(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtVehicleYear_Leave(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboAreaOfOrigin_SelectionChangeCommitted(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboAreaOfOrigin_Leave(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboHeatSource_SelectionChangeCommitted(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboHeatSource_Leave(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboFirstItemIgnited_SelectionChangeCommitted(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboFirstItemIgnited_Leave(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboGenCauseOfIgnition_SelectionChangeCommitted(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboGenCauseOfIgnition_Leave(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboSpecCauseOfIgnition_SelectionChangeCommitted(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboSpecCauseOfIgnition_Leave(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public lstHumanContribFactors_SelectedIndexChanged(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtHFAge_TextChanged(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtFloorOfOrigin_TextChanged(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtFloorOfOrigin_Leave(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public optFloor_CheckStateChanged(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public cboBurnDamage_SelectionChangeCommitted(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboBurnDamage_Leave(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboSmokeDamage_SelectionChangeCommitted(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboSmokeDamage_Leave(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public chkExposures_CheckStateChanged(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public chkMobileInvolved_CheckStateChanged(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtSqFtBurned_TextChanged(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtSqFtBurned_Leave(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtSqFtSmokeDamage_TextChanged(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtSqFtSmokeDamage_Leave(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtPropLoss_TextChanged(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtContentLoss_TextChanged(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public optOSType_CheckedChanged(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public cboOSHeatSource_SelectionChangeCommitted(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboOSHeatSource_Leave(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboOSCauseOfIgnition_SelectionChangeCommitted(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboOSCauseOfIgnition_Leave(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboOSSpecCauseOfIgnition_SelectionChangeCommitted(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboOSSpecCauseOfIgnition_Leave(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtOSLoss_Leave(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtOSAreaAffected_Leave(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboOSAreaUnits_SelectionChangeCommitted(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboOSAreaUnits_Leave(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboOSMaterialInvolved_SelectionChangeCommitted(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboOSMaterialInvolved_Leave(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboNarrList_SelectionChangeCommitted(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdAddNarration_Click(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboNameList_SelectionChangeCommitted(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboNameList_Leave(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtFirstName_TextChanged(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtFirstName_Leave(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtLastName_TextChanged(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtLastName_Leave(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtMI_TextChanged(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtBusinessName_TextChanged(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtBusinessName_Leave(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtHouseNumber_TextChanged(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboPrefix_SelectionChangeCommitted(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboPrefix_Leave(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtStreetName_TextChanged(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboStreetType_SelectionChangeCommitted(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboStreetType_Leave(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboSuffix_SelectionChangeCommitted(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboSuffix_Leave(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtCity_TextChanged(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboState_SelectionChangeCommitted(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboState_Leave(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtZipcode_TextChanged(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboRole_SelectionChangeCommitted(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboRole_Leave(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtHomePhone_TextChanged(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtBirthdate_TextChanged(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public optGender_CheckedChanged(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public txtWorkPhone_TextChanged(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtWorkPlace_TextChanged(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboRace_SelectionChangeCommitted(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboRace_Leave(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public optEthnicity_CheckedChanged(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public cmdMoreNames_Click(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtXHouseNumber_TextChanged(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboXPrefix_SelectionChangeCommitted(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboXPrefix_Leave(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtXStreetName_TextChanged(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboXStreetType_SelectionChangeCommitted(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboXStreetType_Leave(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboXSuffix_SelectionChangeCommitted(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboXSuffix_Leave(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboCityCode_SelectionChangeCommitted(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboCityCode_Leave(sender: frmFireReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

