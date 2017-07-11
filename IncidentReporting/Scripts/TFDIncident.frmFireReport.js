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
define("TFDIncident.frmFireReport", ["files/text!views/TFDIncident.frmFireReport.html", "files/css!views/TFDIncident.frmFireReport.css"], function (htmlTemplate) {
    return (function (_super) {
        __extends(frmFireReport, _super);
        function frmFireReport(model) {
            var _this = _super.call(this, model) || this;
            _this.templateString = htmlTemplate;
            _this.onPostLoad = _this.loaded;
            return _this;
        }
        frmFireReport.prototype.bindings = function () {
            this.bind("cmdHelp_Click", this.cmdHelp_Click);
            this.bind("cmdSave_Click", this.cmdSave_Click);
            this.bind("tabFire_Selecting", this.tabFire_Selecting);
            this.bind("txtTotalSqFootage_TextChanged", this.txtTotalSqFootage_TextChanged);
            this.bind("txtTotalSqFootage_Enter", this.txtTotalSqFootage_Enter);
            this.bind("txtTotalSqFootage_Leave", this.txtTotalSqFootage_Leave);
            this.bind("cboGeneralPropertyUse_SelectionChangeCommitted", this.cboGeneralPropertyUse_SelectionChangeCommitted);
            this.bind("cboGeneralPropertyUse_Enter", this.cboGeneralPropertyUse_Enter);
            this.bind("cboGeneralPropertyUse_Leave", this.cboGeneralPropertyUse_Leave);
            this.bind("txtNumberOfStories_TextChanged", this.txtNumberOfStories_TextChanged);
            this.bind("txtNumberOfUnits_TextChanged", this.txtNumberOfUnits_TextChanged);
            this.bind("cboSpecificPropertyUse_SelectionChangeCommitted", this.cboSpecificPropertyUse_SelectionChangeCommitted);
            this.bind("cboSpecificPropertyUse_Enter", this.cboSpecificPropertyUse_Enter);
            this.bind("txtNumberOfOccupants_TextChanged", this.txtNumberOfOccupants_TextChanged);
            this.bind("cboBuildingStatus_SelectionChangeCommitted", this.cboBuildingStatus_SelectionChangeCommitted);
            this.bind("cboBuildingStatus_Leave", this.cboBuildingStatus_Leave);
            this.bind("txtNumberOfBusinesses_TextChanged", this.txtNumberOfBusinesses_TextChanged);
            this.bind("txtPropValue_TextChanged", this.txtPropValue_TextChanged);
            this.bind("txtPropValue_Enter", this.txtPropValue_Enter);
            this.bind("cboConstructionType_SelectionChangeCommitted", this.cboConstructionType_SelectionChangeCommitted);
            this.bind("cboConstructionType_Leave", this.cboConstructionType_Leave);
            this.bind("optAlarmType_CheckedChanged", this.optAlarmType_CheckedChanged);
            this.bind("chkAlarmOperation_CheckStateChanged", this.chkAlarmOperation_CheckStateChanged);
            this.bind("cboAlarmType_SelectionChangeCommitted", this.cboAlarmType_SelectionChangeCommitted);
            this.bind("cboAlarmType_Leave", this.cboAlarmType_Leave);
            this.bind("cboInitiatingDevice_SelectionChangeCommitted", this.cboInitiatingDevice_SelectionChangeCommitted);
            this.bind("cboInitiatingDevice_Leave", this.cboInitiatingDevice_Leave);
            this.bind("cboEffectiveness_SelectionChangeCommitted", this.cboEffectiveness_SelectionChangeCommitted);
            this.bind("cboEffectiveness_Leave", this.cboEffectiveness_Leave);
            this.bind("optExtinguish_CheckedChanged", this.optExtinguish_CheckedChanged);
            this.bind("chkExtOperation_CheckStateChanged", this.chkExtOperation_CheckStateChanged);
            this.bind("cboSysType_SelectionChangeCommitted", this.cboSysType_SelectionChangeCommitted);
            this.bind("cboSysType_Leave", this.cboSysType_Leave);
            this.bind("cboExtEffectiveness_SelectionChangeCommitted", this.cboExtEffectiveness_SelectionChangeCommitted);
            this.bind("cmdCancelExit_Click", this.cmdCancelExit_Click);
            this.bind("cboMobilePropType_SelectionChangeCommitted", this.cboMobilePropType_SelectionChangeCommitted);
            this.bind("cboMobilePropType_Leave", this.cboMobilePropType_Leave);
            this.bind("txtMobilePropValue_Leave", this.txtMobilePropValue_Leave);
            this.bind("cboMobileMake_SelectionChangeCommitted", this.cboMobileMake_SelectionChangeCommitted);
            this.bind("txtVehicleMake_TextChanged", this.txtVehicleMake_TextChanged);
            this.bind("txtVehicleYear_Leave", this.txtVehicleYear_Leave);
            this.bind("cboAreaOfOrigin_SelectionChangeCommitted", this.cboAreaOfOrigin_SelectionChangeCommitted);
            this.bind("cboAreaOfOrigin_Leave", this.cboAreaOfOrigin_Leave);
            this.bind("cboHeatSource_SelectionChangeCommitted", this.cboHeatSource_SelectionChangeCommitted);
            this.bind("cboHeatSource_Leave", this.cboHeatSource_Leave);
            this.bind("cboFirstItemIgnited_SelectionChangeCommitted", this.cboFirstItemIgnited_SelectionChangeCommitted);
            this.bind("cboFirstItemIgnited_Leave", this.cboFirstItemIgnited_Leave);
            this.bind("cboGenCauseOfIgnition_SelectionChangeCommitted", this.cboGenCauseOfIgnition_SelectionChangeCommitted);
            this.bind("cboGenCauseOfIgnition_Leave", this.cboGenCauseOfIgnition_Leave);
            this.bind("cboSpecCauseOfIgnition_SelectionChangeCommitted", this.cboSpecCauseOfIgnition_SelectionChangeCommitted);
            this.bind("cboSpecCauseOfIgnition_Leave", this.cboSpecCauseOfIgnition_Leave);
            this.bind("lstHumanContribFactors_SelectedIndexChanged", this.lstHumanContribFactors_SelectedIndexChanged);
            this.bind("txtHFAge_TextChanged", this.txtHFAge_TextChanged);
            this.bind("txtFloorOfOrigin_TextChanged", this.txtFloorOfOrigin_TextChanged);
            this.bind("txtFloorOfOrigin_Leave", this.txtFloorOfOrigin_Leave);
            this.bind("optFloor_CheckStateChanged", this.optFloor_CheckStateChanged);
            this.bind("cboBurnDamage_SelectionChangeCommitted", this.cboBurnDamage_SelectionChangeCommitted);
            this.bind("cboBurnDamage_Leave", this.cboBurnDamage_Leave);
            this.bind("cboSmokeDamage_SelectionChangeCommitted", this.cboSmokeDamage_SelectionChangeCommitted);
            this.bind("cboSmokeDamage_Leave", this.cboSmokeDamage_Leave);
            this.bind("chkExposures_CheckStateChanged", this.chkExposures_CheckStateChanged);
            this.bind("chkMobileInvolved_CheckStateChanged", this.chkMobileInvolved_CheckStateChanged);
            this.bind("txtSqFtBurned_TextChanged", this.txtSqFtBurned_TextChanged);
            this.bind("txtSqFtBurned_Leave", this.txtSqFtBurned_Leave);
            this.bind("txtSqFtSmokeDamage_TextChanged", this.txtSqFtSmokeDamage_TextChanged);
            this.bind("txtSqFtSmokeDamage_Leave", this.txtSqFtSmokeDamage_Leave);
            this.bind("txtPropLoss_TextChanged", this.txtPropLoss_TextChanged);
            this.bind("txtContentLoss_TextChanged", this.txtContentLoss_TextChanged);
            this.bind("optOSType_CheckedChanged", this.optOSType_CheckedChanged);
            this.bind("cboOSHeatSource_SelectionChangeCommitted", this.cboOSHeatSource_SelectionChangeCommitted);
            this.bind("cboOSHeatSource_Leave", this.cboOSHeatSource_Leave);
            this.bind("cboOSCauseOfIgnition_SelectionChangeCommitted", this.cboOSCauseOfIgnition_SelectionChangeCommitted);
            this.bind("cboOSCauseOfIgnition_Leave", this.cboOSCauseOfIgnition_Leave);
            this.bind("cboOSSpecCauseOfIgnition_SelectionChangeCommitted", this.cboOSSpecCauseOfIgnition_SelectionChangeCommitted);
            this.bind("cboOSSpecCauseOfIgnition_Leave", this.cboOSSpecCauseOfIgnition_Leave);
            this.bind("txtOSLoss_Leave", this.txtOSLoss_Leave);
            this.bind("txtOSAreaAffected_Leave", this.txtOSAreaAffected_Leave);
            this.bind("cboOSAreaUnits_SelectionChangeCommitted", this.cboOSAreaUnits_SelectionChangeCommitted);
            this.bind("cboOSAreaUnits_Leave", this.cboOSAreaUnits_Leave);
            this.bind("cboOSMaterialInvolved_SelectionChangeCommitted", this.cboOSMaterialInvolved_SelectionChangeCommitted);
            this.bind("cboOSMaterialInvolved_Leave", this.cboOSMaterialInvolved_Leave);
            this.bind("cboNarrList_SelectionChangeCommitted", this.cboNarrList_SelectionChangeCommitted);
            this.bind("cmdAddNarration_Click", this.cmdAddNarration_Click);
            this.bind("cboNameList_SelectionChangeCommitted", this.cboNameList_SelectionChangeCommitted);
            this.bind("cboNameList_Leave", this.cboNameList_Leave);
            this.bind("txtFirstName_TextChanged", this.txtFirstName_TextChanged);
            this.bind("txtFirstName_Leave", this.txtFirstName_Leave);
            this.bind("txtLastName_TextChanged", this.txtLastName_TextChanged);
            this.bind("txtLastName_Leave", this.txtLastName_Leave);
            this.bind("txtMI_TextChanged", this.txtMI_TextChanged);
            this.bind("txtBusinessName_TextChanged", this.txtBusinessName_TextChanged);
            this.bind("txtBusinessName_Leave", this.txtBusinessName_Leave);
            this.bind("txtHouseNumber_TextChanged", this.txtHouseNumber_TextChanged);
            this.bind("cboPrefix_SelectionChangeCommitted", this.cboPrefix_SelectionChangeCommitted);
            this.bind("cboPrefix_Leave", this.cboPrefix_Leave);
            this.bind("txtStreetName_TextChanged", this.txtStreetName_TextChanged);
            this.bind("cboStreetType_SelectionChangeCommitted", this.cboStreetType_SelectionChangeCommitted);
            this.bind("cboStreetType_Leave", this.cboStreetType_Leave);
            this.bind("cboSuffix_SelectionChangeCommitted", this.cboSuffix_SelectionChangeCommitted);
            this.bind("cboSuffix_Leave", this.cboSuffix_Leave);
            this.bind("txtCity_TextChanged", this.txtCity_TextChanged);
            this.bind("cboState_SelectionChangeCommitted", this.cboState_SelectionChangeCommitted);
            this.bind("cboState_Leave", this.cboState_Leave);
            this.bind("txtZipcode_TextChanged", this.txtZipcode_TextChanged);
            this.bind("cboRole_SelectionChangeCommitted", this.cboRole_SelectionChangeCommitted);
            this.bind("cboRole_Leave", this.cboRole_Leave);
            this.bind("txtHomePhone_TextChanged", this.txtHomePhone_TextChanged);
            this.bind("txtBirthdate_TextChanged", this.txtBirthdate_TextChanged);
            this.bind("optGender_CheckedChanged", this.optGender_CheckedChanged);
            this.bind("txtWorkPhone_TextChanged", this.txtWorkPhone_TextChanged);
            this.bind("txtWorkPlace_TextChanged", this.txtWorkPlace_TextChanged);
            this.bind("cboRace_SelectionChangeCommitted", this.cboRace_SelectionChangeCommitted);
            this.bind("cboRace_Leave", this.cboRace_Leave);
            this.bind("optEthnicity_CheckedChanged", this.optEthnicity_CheckedChanged);
            this.bind("cmdMoreNames_Click", this.cmdMoreNames_Click);
            this.bind("txtXHouseNumber_TextChanged", this.txtXHouseNumber_TextChanged);
            this.bind("cboXPrefix_SelectionChangeCommitted", this.cboXPrefix_SelectionChangeCommitted);
            this.bind("cboXPrefix_Leave", this.cboXPrefix_Leave);
            this.bind("txtXStreetName_TextChanged", this.txtXStreetName_TextChanged);
            this.bind("cboXStreetType_SelectionChangeCommitted", this.cboXStreetType_SelectionChangeCommitted);
            this.bind("cboXStreetType_Leave", this.cboXStreetType_Leave);
            this.bind("cboXSuffix_SelectionChangeCommitted", this.cboXSuffix_SelectionChangeCommitted);
            this.bind("cboXSuffix_Leave", this.cboXSuffix_Leave);
            this.bind("cboCityCode_SelectionChangeCommitted", this.cboCityCode_SelectionChangeCommitted);
            this.bind("cboCityCode_Leave", this.cboCityCode_Leave);
            //this.bindCloseEvent();
        };
        Object.defineProperty(frmFireReport.prototype, "name", {
            get: function () {
                return "frmFireReport";
            },
            enumerable: true,
            configurable: true
        });
        frmFireReport.prototype.loaded = function () {
        };
        frmFireReport.prototype.frmFireReport_Close = function (e) {
            if (e.userTriggered) {
                window.app.sendAction({ mainobj: this, controller: "frmFireReport", action: "frmFireReport_Close" });
                e.preventDefault();
            }
        };
        frmFireReport.prototype.cmdHelp_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cmdSave_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        frmFireReport.prototype.tabFire_Selecting = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.txtTotalSqFootage_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.txtTotalSqFootage_Enter = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.txtTotalSqFootage_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboGeneralPropertyUse_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboGeneralPropertyUse_Enter = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboGeneralPropertyUse_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.txtNumberOfStories_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.txtNumberOfUnits_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboSpecificPropertyUse_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboSpecificPropertyUse_Enter = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.txtNumberOfOccupants_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboBuildingStatus_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboBuildingStatus_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.txtNumberOfBusinesses_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.txtPropValue_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.txtPropValue_Enter = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboConstructionType_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboConstructionType_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.optAlarmType_CheckedChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        frmFireReport.prototype.chkAlarmOperation_CheckStateChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboAlarmType_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboAlarmType_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboInitiatingDevice_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboInitiatingDevice_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboEffectiveness_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboEffectiveness_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.optExtinguish_CheckedChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        frmFireReport.prototype.chkExtOperation_CheckStateChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboSysType_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboSysType_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboExtEffectiveness_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cmdCancelExit_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboMobilePropType_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboMobilePropType_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.txtMobilePropValue_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboMobileMake_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.txtVehicleMake_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.txtVehicleYear_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboAreaOfOrigin_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboAreaOfOrigin_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboHeatSource_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboHeatSource_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboFirstItemIgnited_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboFirstItemIgnited_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboGenCauseOfIgnition_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboGenCauseOfIgnition_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboSpecCauseOfIgnition_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboSpecCauseOfIgnition_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.lstHumanContribFactors_SelectedIndexChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.txtHFAge_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.txtFloorOfOrigin_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.txtFloorOfOrigin_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.optFloor_CheckStateChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        frmFireReport.prototype.cboBurnDamage_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboBurnDamage_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboSmokeDamage_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboSmokeDamage_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.chkExposures_CheckStateChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.chkMobileInvolved_CheckStateChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.txtSqFtBurned_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.txtSqFtBurned_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.txtSqFtSmokeDamage_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.txtSqFtSmokeDamage_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.txtPropLoss_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.txtContentLoss_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.optOSType_CheckedChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        frmFireReport.prototype.cboOSHeatSource_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboOSHeatSource_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboOSCauseOfIgnition_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboOSCauseOfIgnition_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboOSSpecCauseOfIgnition_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboOSSpecCauseOfIgnition_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.txtOSLoss_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.txtOSAreaAffected_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboOSAreaUnits_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboOSAreaUnits_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboOSMaterialInvolved_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboOSMaterialInvolved_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboNarrList_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cmdAddNarration_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboNameList_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboNameList_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.txtFirstName_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.txtFirstName_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.txtLastName_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.txtLastName_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.txtMI_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.txtBusinessName_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.txtBusinessName_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.txtHouseNumber_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboPrefix_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboPrefix_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.txtStreetName_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboStreetType_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboStreetType_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboSuffix_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboSuffix_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.txtCity_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboState_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboState_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.txtZipcode_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboRole_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboRole_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.txtHomePhone_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.txtBirthdate_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.optGender_CheckedChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        frmFireReport.prototype.txtWorkPhone_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.txtWorkPlace_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboRace_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboRace_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.optEthnicity_CheckedChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        frmFireReport.prototype.cmdMoreNames_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.txtXHouseNumber_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboXPrefix_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboXPrefix_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.txtXStreetName_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboXStreetType_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboXStreetType_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboXSuffix_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboXSuffix_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboCityCode_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmFireReport.prototype.cboCityCode_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        return frmFireReport;
    }(Mobilize.WebMap.Kendo.Ui.KendoView));
});
//# sourceMappingURL=TFDIncident.frmFireReport.js.map