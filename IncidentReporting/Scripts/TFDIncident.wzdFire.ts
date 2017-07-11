/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("TFDIncident.wzdFire", [ "files/text!views/TFDIncident.wzdFire.html", "files/css!views/TFDIncident.wzdFire.css"],
    (htmlTemplate) => {
    return class wzdFire extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("txtFloorOfOrigin_TextChanged",this.txtFloorOfOrigin_TextChanged);
this.bind("optFloor_CheckStateChanged",this.optFloor_CheckStateChanged);
this.bind("cboBurnDamage_SelectionChangeCommitted",this.cboBurnDamage_SelectionChangeCommitted);
this.bind("cboSmokeDamage_SelectionChangeCommitted",this.cboSmokeDamage_SelectionChangeCommitted);
this.bind("lstItemContribFireSpread_SelectedIndexChanged",this.lstItemContribFireSpread_SelectedIndexChanged);
this.bind("lstEquipInvolvIgnition_SelectedIndexChanged",this.lstEquipInvolvIgnition_SelectedIndexChanged);
this.bind("cboAreaOfOrigin_SelectionChangeCommitted",this.cboAreaOfOrigin_SelectionChangeCommitted);
this.bind("cboHeatSource_SelectionChangeCommitted",this.cboHeatSource_SelectionChangeCommitted);
this.bind("cboFirstItemIgnited_SelectionChangeCommitted",this.cboFirstItemIgnited_SelectionChangeCommitted);
this.bind("cboGenCauseOfIgnition_SelectionChangeCommitted",this.cboGenCauseOfIgnition_SelectionChangeCommitted);
this.bind("cboSpecCauseOfIgnition_SelectionChangeCommitted",this.cboSpecCauseOfIgnition_SelectionChangeCommitted);
this.bind("lstPhysicalContribFactors_SelectedIndexChanged",this.lstPhysicalContribFactors_SelectedIndexChanged);
this.bind("lstHumanContribFactors_SelectedIndexChanged",this.lstHumanContribFactors_SelectedIndexChanged);
this.bind("txtHFAge_TextChanged",this.txtHFAge_TextChanged);
this.bind("lstSuppressionFactors_SelectedIndexChanged",this.lstSuppressionFactors_SelectedIndexChanged);
this.bind("optType_CheckedChanged",this.optType_CheckedChanged);
this.bind("chkExposures_CheckStateChanged",this.chkExposures_CheckStateChanged);
this.bind("txtNumberExposures_TextChanged",this.txtNumberExposures_TextChanged);
this.bind("chkAddressCorrection_CheckStateChanged",this.chkAddressCorrection_CheckStateChanged);
this.bind("cmdSave_Click",this.cmdSave_Click);
this.bind("cmdSaveIncomplete_Click",this.cmdSaveIncomplete_Click);
this.bind("cmdAbandon_Click",this.cmdAbandon_Click);
this.bind("cboOSHeatSource_SelectionChangeCommitted",this.cboOSHeatSource_SelectionChangeCommitted);
this.bind("cboOSCauseOfIgnition_SelectionChangeCommitted",this.cboOSCauseOfIgnition_SelectionChangeCommitted);
this.bind("cboOSSpecCauseOfIgnition_SelectionChangeCommitted",this.cboOSSpecCauseOfIgnition_SelectionChangeCommitted);
this.bind("txtOSLoss_TextChanged",this.txtOSLoss_TextChanged);
this.bind("cboOSAreaUnits_SelectionChangeCommitted",this.cboOSAreaUnits_SelectionChangeCommitted);
this.bind("txtOSAreaAffected_TextChanged",this.txtOSAreaAffected_TextChanged);
this.bind("cboOSMaterialInvolved_SelectionChangeCommitted",this.cboOSMaterialInvolved_SelectionChangeCommitted);
this.bind("txtFirstName_TextChanged",this.txtFirstName_TextChanged);
this.bind("txtLastName_TextChanged",this.txtLastName_TextChanged);
this.bind("txtMI_TextChanged",this.txtMI_TextChanged);
this.bind("txtBusinessName_TextChanged",this.txtBusinessName_TextChanged);
this.bind("txtHouseNumber_TextChanged",this.txtHouseNumber_TextChanged);
this.bind("cboPrefix_SelectionChangeCommitted",this.cboPrefix_SelectionChangeCommitted);
this.bind("txtStreetName_TextChanged",this.txtStreetName_TextChanged);
this.bind("cboStreetType_SelectionChangeCommitted",this.cboStreetType_SelectionChangeCommitted);
this.bind("cboSuffix_SelectionChangeCommitted",this.cboSuffix_SelectionChangeCommitted);
this.bind("txtZipcode_TextChanged",this.txtZipcode_TextChanged);
this.bind("cboRole_SelectionChangeCommitted",this.cboRole_SelectionChangeCommitted);
this.bind("txtHomePhone_TextChanged",this.txtHomePhone_TextChanged);
this.bind("calBirthdate_Click", this.calBirthdate_Click);
this.bind("txtWorkPhone_TextChanged",this.txtWorkPhone_TextChanged);
this.bind("optGender_CheckedChanged",this.optGender_CheckedChanged);
this.bind("txtWorkPlace_TextChanged",this.txtWorkPlace_TextChanged);
this.bind("cboRace_SelectionChangeCommitted",this.cboRace_SelectionChangeCommitted);
this.bind("cmdAddNewName_Click",this.cmdAddNewName_Click);
this.bind("cboMobilePropType_SelectionChangeCommitted",this.cboMobilePropType_SelectionChangeCommitted);
this.bind("txtMobilePropValue_TextChanged",this.txtMobilePropValue_TextChanged);
this.bind("cboMobileMake_SelectionChangeCommitted",this.cboMobileMake_SelectionChangeCommitted);
this.bind("txtVehicleMake_TextChanged",this.txtVehicleMake_TextChanged);
this.bind("txtVehicleYear_Leave",this.txtVehicleYear_Leave);
this.bind("rtxNarration_Click",this.rtxNarration_Click);
this.bind("cmdAddNames_Click",this.cmdAddNames_Click);
this.bind("txtSqFtBurned_Leave",this.txtSqFtBurned_Leave);
this.bind("txtSqFtBurned_TextChanged",this.txtSqFtBurned_TextChanged);
this.bind("txtSqFtSmokeDamage_Leave",this.txtSqFtSmokeDamage_Leave);
this.bind("txtSqFtSmokeDamage_TextChanged",this.txtSqFtSmokeDamage_TextChanged);
this.bind("txtNoBusinessDisplaced_TextChanged",this.txtNoBusinessDisplaced_TextChanged);
this.bind("txtNoPeopleDisplaced_TextChanged",this.txtNoPeopleDisplaced_TextChanged);
this.bind("txtJobsLost_TextChanged",this.txtJobsLost_TextChanged);
this.bind("txtPropLoss_TextChanged",this.txtPropLoss_TextChanged);
this.bind("txtContentLoss_TextChanged",this.txtContentLoss_TextChanged);
this.bind("txtTotalSqFootage_Leave",this.txtTotalSqFootage_Leave);
this.bind("txtTotalSqFootage_TextChanged",this.txtTotalSqFootage_TextChanged);
this.bind("txtNumberOfStories_TextChanged",this.txtNumberOfStories_TextChanged);
this.bind("txtBasementLevels_TextChanged",this.txtBasementLevels_TextChanged);
this.bind("cboGeneralPropertyUse_SelectionChangeCommitted",this.cboGeneralPropertyUse_SelectionChangeCommitted);
this.bind("txtNumberOfUnits_TextChanged",this.txtNumberOfUnits_TextChanged);
this.bind("cboSpecificPropertyUse_SelectionChangeCommitted",this.cboSpecificPropertyUse_SelectionChangeCommitted);
this.bind("txtNumberOfOccupants_TextChanged",this.txtNumberOfOccupants_TextChanged);
this.bind("cboBuildingStatus_SelectionChangeCommitted",this.cboBuildingStatus_SelectionChangeCommitted);
this.bind("txtNumberOfBusinesses_TextChanged",this.txtNumberOfBusinesses_TextChanged);
this.bind("txtPropValue_TextChanged",this.txtPropValue_TextChanged);
this.bind("cboConstructionType_SelectionChangeCommitted",this.cboConstructionType_SelectionChangeCommitted);
this.bind("optAlarmType_CheckedChanged",this.optAlarmType_CheckedChanged);
this.bind("chkAlarmOperated_CheckStateChanged",this.chkAlarmOperated_CheckStateChanged);
this.bind("cboAlarmType_SelectionChangeCommitted",this.cboAlarmType_SelectionChangeCommitted);
this.bind("lstAlarmFailure_SelectedIndexChanged",this.lstAlarmFailure_SelectedIndexChanged);
this.bind("cboInitiatingDevice_SelectionChangeCommitted",this.cboInitiatingDevice_SelectionChangeCommitted);
this.bind("cboEffectiveness_SelectionChangeCommitted",this.cboEffectiveness_SelectionChangeCommitted);
this.bind("optExtinguish_CheckedChanged",this.optExtinguish_CheckedChanged);
this.bind("lstExtFailure_SelectedIndexChanged",this.lstExtFailure_SelectedIndexChanged);
this.bind("cboSysType_SelectionChangeCommitted",this.cboSysType_SelectionChangeCommitted);
this.bind("cboExtEffectiveness_SelectionChangeCommitted",this.cboExtEffectiveness_SelectionChangeCommitted);
this.bind("txtXHouseNumber_TextChanged",this.txtXHouseNumber_TextChanged);
this.bind("cboXPrefix_SelectionChangeCommitted",this.cboXPrefix_SelectionChangeCommitted);
this.bind("txtXStreetName_TextChanged",this.txtXStreetName_TextChanged);
this.bind("cboXSuffix_SelectionChangeCommitted",this.cboXSuffix_SelectionChangeCommitted);
this.bind("cboCityCode_SelectionChangeCommitted",this.cboCityCode_SelectionChangeCommitted);
this.bind("NavButton_Click",this.NavButton_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "wzdFire";
            }

            public loaded() {
			
            }

        

        public wzdFire_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"wzdFire",action:"wzdFire_Close"});
                e.preventDefault();
            }
            
        }
        public txtFloorOfOrigin_TextChanged(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public optFloor_CheckStateChanged(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public cboBurnDamage_SelectionChangeCommitted(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboSmokeDamage_SelectionChangeCommitted(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public lstItemContribFireSpread_SelectedIndexChanged(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public lstEquipInvolvIgnition_SelectedIndexChanged(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboAreaOfOrigin_SelectionChangeCommitted(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboHeatSource_SelectionChangeCommitted(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboFirstItemIgnited_SelectionChangeCommitted(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboGenCauseOfIgnition_SelectionChangeCommitted(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboSpecCauseOfIgnition_SelectionChangeCommitted(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public lstPhysicalContribFactors_SelectedIndexChanged(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public lstHumanContribFactors_SelectedIndexChanged(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtHFAge_TextChanged(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public lstSuppressionFactors_SelectedIndexChanged(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public optType_CheckedChanged(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public chkExposures_CheckStateChanged(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtNumberExposures_TextChanged(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public chkAddressCorrection_CheckStateChanged(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdSave_Click(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdSaveIncomplete_Click(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdAbandon_Click(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboOSHeatSource_SelectionChangeCommitted(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboOSCauseOfIgnition_SelectionChangeCommitted(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboOSSpecCauseOfIgnition_SelectionChangeCommitted(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtOSLoss_TextChanged(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboOSAreaUnits_SelectionChangeCommitted(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtOSAreaAffected_TextChanged(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboOSMaterialInvolved_SelectionChangeCommitted(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtFirstName_TextChanged(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtLastName_TextChanged(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtMI_TextChanged(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtBusinessName_TextChanged(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtHouseNumber_TextChanged(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboPrefix_SelectionChangeCommitted(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtStreetName_TextChanged(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboStreetType_SelectionChangeCommitted(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboSuffix_SelectionChangeCommitted(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtZipcode_TextChanged(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboRole_SelectionChangeCommitted(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtHomePhone_TextChanged(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public calBirthdate_Click(sender: wzdFire, action: string, e: any) {

            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

        }
        public txtWorkPhone_TextChanged(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public optGender_CheckedChanged(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public txtWorkPlace_TextChanged(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboRace_SelectionChangeCommitted(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdAddNewName_Click(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboMobilePropType_SelectionChangeCommitted(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtMobilePropValue_TextChanged(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboMobileMake_SelectionChangeCommitted(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtVehicleMake_TextChanged(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtVehicleYear_Leave(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public rtxNarration_Click(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdAddNames_Click(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtSqFtBurned_Leave(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtSqFtBurned_TextChanged(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtSqFtSmokeDamage_Leave(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtSqFtSmokeDamage_TextChanged(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtNoBusinessDisplaced_TextChanged(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtNoPeopleDisplaced_TextChanged(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtJobsLost_TextChanged(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtPropLoss_TextChanged(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtContentLoss_TextChanged(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtTotalSqFootage_Leave(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtTotalSqFootage_TextChanged(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtNumberOfStories_TextChanged(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtBasementLevels_TextChanged(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboGeneralPropertyUse_SelectionChangeCommitted(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtNumberOfUnits_TextChanged(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboSpecificPropertyUse_SelectionChangeCommitted(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtNumberOfOccupants_TextChanged(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboBuildingStatus_SelectionChangeCommitted(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtNumberOfBusinesses_TextChanged(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtPropValue_TextChanged(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboConstructionType_SelectionChangeCommitted(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public optAlarmType_CheckedChanged(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public chkAlarmOperated_CheckStateChanged(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboAlarmType_SelectionChangeCommitted(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public lstAlarmFailure_SelectedIndexChanged(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboInitiatingDevice_SelectionChangeCommitted(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboEffectiveness_SelectionChangeCommitted(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public optExtinguish_CheckedChanged(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public lstExtFailure_SelectedIndexChanged(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboSysType_SelectionChangeCommitted(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboExtEffectiveness_SelectionChangeCommitted(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtXHouseNumber_TextChanged(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboXPrefix_SelectionChangeCommitted(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtXStreetName_TextChanged(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboXSuffix_SelectionChangeCommitted(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboCityCode_SelectionChangeCommitted(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public NavButton_Click(sender: wzdFire, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }

    }
   
});

