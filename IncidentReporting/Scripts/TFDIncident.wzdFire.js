/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
define("TFDIncident.wzdFire", ["files/text!views/TFDIncident.wzdFire.html", "files/css!views/TFDIncident.wzdFire.css"], function (htmlTemplate) {
    return (function (_super) {
        __extends(wzdFire, _super);
        function wzdFire(model) {
            var _this = _super.call(this, model) || this;
            _this.templateString = htmlTemplate;
            _this.onPostLoad = _this.loaded;
            return _this;
        }
        wzdFire.prototype.bindings = function () {
            this.bind("txtFloorOfOrigin_TextChanged", this.txtFloorOfOrigin_TextChanged);
            this.bind("optFloor_CheckStateChanged", this.optFloor_CheckStateChanged);
            this.bind("cboBurnDamage_SelectionChangeCommitted", this.cboBurnDamage_SelectionChangeCommitted);
            this.bind("cboSmokeDamage_SelectionChangeCommitted", this.cboSmokeDamage_SelectionChangeCommitted);
            this.bind("lstItemContribFireSpread_SelectedIndexChanged", this.lstItemContribFireSpread_SelectedIndexChanged);
            this.bind("lstEquipInvolvIgnition_SelectedIndexChanged", this.lstEquipInvolvIgnition_SelectedIndexChanged);
            this.bind("cboAreaOfOrigin_SelectionChangeCommitted", this.cboAreaOfOrigin_SelectionChangeCommitted);
            this.bind("cboHeatSource_SelectionChangeCommitted", this.cboHeatSource_SelectionChangeCommitted);
            this.bind("cboFirstItemIgnited_SelectionChangeCommitted", this.cboFirstItemIgnited_SelectionChangeCommitted);
            this.bind("cboGenCauseOfIgnition_SelectionChangeCommitted", this.cboGenCauseOfIgnition_SelectionChangeCommitted);
            this.bind("cboSpecCauseOfIgnition_SelectionChangeCommitted", this.cboSpecCauseOfIgnition_SelectionChangeCommitted);
            this.bind("lstPhysicalContribFactors_SelectedIndexChanged", this.lstPhysicalContribFactors_SelectedIndexChanged);
            this.bind("lstHumanContribFactors_SelectedIndexChanged", this.lstHumanContribFactors_SelectedIndexChanged);
            this.bind("txtHFAge_TextChanged", this.txtHFAge_TextChanged);
            this.bind("lstSuppressionFactors_SelectedIndexChanged", this.lstSuppressionFactors_SelectedIndexChanged);
            this.bind("optType_CheckedChanged", this.optType_CheckedChanged);
            this.bind("chkExposures_CheckStateChanged", this.chkExposures_CheckStateChanged);
            this.bind("txtNumberExposures_TextChanged", this.txtNumberExposures_TextChanged);
            this.bind("chkAddressCorrection_CheckStateChanged", this.chkAddressCorrection_CheckStateChanged);
            this.bind("cmdSave_Click", this.cmdSave_Click);
            this.bind("cmdSaveIncomplete_Click", this.cmdSaveIncomplete_Click);
            this.bind("cmdAbandon_Click", this.cmdAbandon_Click);
            this.bind("cboOSHeatSource_SelectionChangeCommitted", this.cboOSHeatSource_SelectionChangeCommitted);
            this.bind("cboOSCauseOfIgnition_SelectionChangeCommitted", this.cboOSCauseOfIgnition_SelectionChangeCommitted);
            this.bind("cboOSSpecCauseOfIgnition_SelectionChangeCommitted", this.cboOSSpecCauseOfIgnition_SelectionChangeCommitted);
            this.bind("txtOSLoss_TextChanged", this.txtOSLoss_TextChanged);
            this.bind("cboOSAreaUnits_SelectionChangeCommitted", this.cboOSAreaUnits_SelectionChangeCommitted);
            this.bind("txtOSAreaAffected_TextChanged", this.txtOSAreaAffected_TextChanged);
            this.bind("cboOSMaterialInvolved_SelectionChangeCommitted", this.cboOSMaterialInvolved_SelectionChangeCommitted);
            this.bind("txtFirstName_TextChanged", this.txtFirstName_TextChanged);
            this.bind("txtLastName_TextChanged", this.txtLastName_TextChanged);
            this.bind("txtMI_TextChanged", this.txtMI_TextChanged);
            this.bind("txtBusinessName_TextChanged", this.txtBusinessName_TextChanged);
            this.bind("txtHouseNumber_TextChanged", this.txtHouseNumber_TextChanged);
            this.bind("cboPrefix_SelectionChangeCommitted", this.cboPrefix_SelectionChangeCommitted);
            this.bind("txtStreetName_TextChanged", this.txtStreetName_TextChanged);
            this.bind("cboStreetType_SelectionChangeCommitted", this.cboStreetType_SelectionChangeCommitted);
            this.bind("cboSuffix_SelectionChangeCommitted", this.cboSuffix_SelectionChangeCommitted);
            this.bind("txtZipcode_TextChanged", this.txtZipcode_TextChanged);
            this.bind("cboRole_SelectionChangeCommitted", this.cboRole_SelectionChangeCommitted);
            this.bind("txtHomePhone_TextChanged", this.txtHomePhone_TextChanged);
            this.bind("calBirthdate_Click", this.calBirthdate_Click);
            this.bind("txtWorkPhone_TextChanged", this.txtWorkPhone_TextChanged);
            this.bind("optGender_CheckedChanged", this.optGender_CheckedChanged);
            this.bind("txtWorkPlace_TextChanged", this.txtWorkPlace_TextChanged);
            this.bind("cboRace_SelectionChangeCommitted", this.cboRace_SelectionChangeCommitted);
            this.bind("cmdAddNewName_Click", this.cmdAddNewName_Click);
            this.bind("cboMobilePropType_SelectionChangeCommitted", this.cboMobilePropType_SelectionChangeCommitted);
            this.bind("txtMobilePropValue_TextChanged", this.txtMobilePropValue_TextChanged);
            this.bind("cboMobileMake_SelectionChangeCommitted", this.cboMobileMake_SelectionChangeCommitted);
            this.bind("txtVehicleMake_TextChanged", this.txtVehicleMake_TextChanged);
            this.bind("txtVehicleYear_Leave", this.txtVehicleYear_Leave);
            this.bind("rtxNarration_Click", this.rtxNarration_Click);
            this.bind("cmdAddNames_Click", this.cmdAddNames_Click);
            this.bind("txtSqFtBurned_Leave", this.txtSqFtBurned_Leave);
            this.bind("txtSqFtBurned_TextChanged", this.txtSqFtBurned_TextChanged);
            this.bind("txtSqFtSmokeDamage_Leave", this.txtSqFtSmokeDamage_Leave);
            this.bind("txtSqFtSmokeDamage_TextChanged", this.txtSqFtSmokeDamage_TextChanged);
            this.bind("txtNoBusinessDisplaced_TextChanged", this.txtNoBusinessDisplaced_TextChanged);
            this.bind("txtNoPeopleDisplaced_TextChanged", this.txtNoPeopleDisplaced_TextChanged);
            this.bind("txtJobsLost_TextChanged", this.txtJobsLost_TextChanged);
            this.bind("txtPropLoss_TextChanged", this.txtPropLoss_TextChanged);
            this.bind("txtContentLoss_TextChanged", this.txtContentLoss_TextChanged);
            this.bind("txtTotalSqFootage_Leave", this.txtTotalSqFootage_Leave);
            this.bind("txtTotalSqFootage_TextChanged", this.txtTotalSqFootage_TextChanged);
            this.bind("txtNumberOfStories_TextChanged", this.txtNumberOfStories_TextChanged);
            this.bind("txtBasementLevels_TextChanged", this.txtBasementLevels_TextChanged);
            this.bind("cboGeneralPropertyUse_SelectionChangeCommitted", this.cboGeneralPropertyUse_SelectionChangeCommitted);
            this.bind("txtNumberOfUnits_TextChanged", this.txtNumberOfUnits_TextChanged);
            this.bind("cboSpecificPropertyUse_SelectionChangeCommitted", this.cboSpecificPropertyUse_SelectionChangeCommitted);
            this.bind("txtNumberOfOccupants_TextChanged", this.txtNumberOfOccupants_TextChanged);
            this.bind("cboBuildingStatus_SelectionChangeCommitted", this.cboBuildingStatus_SelectionChangeCommitted);
            this.bind("txtNumberOfBusinesses_TextChanged", this.txtNumberOfBusinesses_TextChanged);
            this.bind("txtPropValue_TextChanged", this.txtPropValue_TextChanged);
            this.bind("cboConstructionType_SelectionChangeCommitted", this.cboConstructionType_SelectionChangeCommitted);
            this.bind("optAlarmType_CheckedChanged", this.optAlarmType_CheckedChanged);
            this.bind("chkAlarmOperated_CheckStateChanged", this.chkAlarmOperated_CheckStateChanged);
            this.bind("cboAlarmType_SelectionChangeCommitted", this.cboAlarmType_SelectionChangeCommitted);
            this.bind("lstAlarmFailure_SelectedIndexChanged", this.lstAlarmFailure_SelectedIndexChanged);
            this.bind("cboInitiatingDevice_SelectionChangeCommitted", this.cboInitiatingDevice_SelectionChangeCommitted);
            this.bind("cboEffectiveness_SelectionChangeCommitted", this.cboEffectiveness_SelectionChangeCommitted);
            this.bind("optExtinguish_CheckedChanged", this.optExtinguish_CheckedChanged);
            this.bind("lstExtFailure_SelectedIndexChanged", this.lstExtFailure_SelectedIndexChanged);
            this.bind("cboSysType_SelectionChangeCommitted", this.cboSysType_SelectionChangeCommitted);
            this.bind("cboExtEffectiveness_SelectionChangeCommitted", this.cboExtEffectiveness_SelectionChangeCommitted);
            this.bind("txtXHouseNumber_TextChanged", this.txtXHouseNumber_TextChanged);
            this.bind("cboXPrefix_SelectionChangeCommitted", this.cboXPrefix_SelectionChangeCommitted);
            this.bind("txtXStreetName_TextChanged", this.txtXStreetName_TextChanged);
            this.bind("cboXSuffix_SelectionChangeCommitted", this.cboXSuffix_SelectionChangeCommitted);
            this.bind("cboCityCode_SelectionChangeCommitted", this.cboCityCode_SelectionChangeCommitted);
            this.bind("NavButton_Click", this.NavButton_Click);
            //this.bindCloseEvent();
        };
        Object.defineProperty(wzdFire.prototype, "name", {
            get: function () {
                return "wzdFire";
            },
            enumerable: true,
            configurable: true
        });
        wzdFire.prototype.loaded = function () {
        };
        wzdFire.prototype.wzdFire_Close = function (e) {
            if (e.userTriggered) {
                window.app.sendAction({ mainobj: this, controller: "wzdFire", action: "wzdFire_Close" });
                e.preventDefault();
            }
        };
        wzdFire.prototype.txtFloorOfOrigin_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.optFloor_CheckStateChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        wzdFire.prototype.cboBurnDamage_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.cboSmokeDamage_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.lstItemContribFireSpread_SelectedIndexChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.lstEquipInvolvIgnition_SelectedIndexChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.cboAreaOfOrigin_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.cboHeatSource_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.cboFirstItemIgnited_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.cboGenCauseOfIgnition_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.cboSpecCauseOfIgnition_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.lstPhysicalContribFactors_SelectedIndexChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.lstHumanContribFactors_SelectedIndexChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.txtHFAge_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.lstSuppressionFactors_SelectedIndexChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.optType_CheckedChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        wzdFire.prototype.chkExposures_CheckStateChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.txtNumberExposures_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.chkAddressCorrection_CheckStateChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.cmdSave_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.cmdSaveIncomplete_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.cmdAbandon_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.cboOSHeatSource_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.cboOSCauseOfIgnition_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.cboOSSpecCauseOfIgnition_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.txtOSLoss_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.cboOSAreaUnits_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.txtOSAreaAffected_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.cboOSMaterialInvolved_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.txtFirstName_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.txtLastName_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.txtMI_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.txtBusinessName_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.txtHouseNumber_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.cboPrefix_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.txtStreetName_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.cboStreetType_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.cboSuffix_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.txtZipcode_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.cboRole_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.txtHomePhone_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.calBirthdate_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.txtWorkPhone_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.optGender_CheckedChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        wzdFire.prototype.txtWorkPlace_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.cboRace_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.cmdAddNewName_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.cboMobilePropType_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.txtMobilePropValue_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.cboMobileMake_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.txtVehicleMake_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.txtVehicleYear_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.rtxNarration_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.cmdAddNames_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.txtSqFtBurned_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.txtSqFtBurned_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.txtSqFtSmokeDamage_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.txtSqFtSmokeDamage_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.txtNoBusinessDisplaced_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.txtNoPeopleDisplaced_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.txtJobsLost_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.txtPropLoss_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.txtContentLoss_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.txtTotalSqFootage_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.txtTotalSqFootage_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.txtNumberOfStories_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.txtBasementLevels_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.cboGeneralPropertyUse_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.txtNumberOfUnits_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.cboSpecificPropertyUse_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.txtNumberOfOccupants_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.cboBuildingStatus_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.txtNumberOfBusinesses_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.txtPropValue_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.cboConstructionType_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.optAlarmType_CheckedChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        wzdFire.prototype.chkAlarmOperated_CheckStateChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.cboAlarmType_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.lstAlarmFailure_SelectedIndexChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.cboInitiatingDevice_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.cboEffectiveness_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.optExtinguish_CheckedChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        wzdFire.prototype.lstExtFailure_SelectedIndexChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.cboSysType_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.cboExtEffectiveness_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.txtXHouseNumber_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.cboXPrefix_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.txtXStreetName_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.cboXSuffix_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.cboCityCode_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdFire.prototype.NavButton_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        return wzdFire;
    }(Mobilize.WebMap.Kendo.Ui.KendoView));
});
//# sourceMappingURL=TFDIncident.wzdFire.js.map