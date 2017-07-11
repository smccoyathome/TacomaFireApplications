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
define("TFDIncident.frmHazmatReport", ["files/text!views/TFDIncident.frmHazmatReport.html", "files/css!views/TFDIncident.frmHazmatReport.css"], function (htmlTemplate) {
    return (function (_super) {
        __extends(frmHazmatReport, _super);
        function frmHazmatReport(model) {
            var _this = _super.call(this, model) || this;
            _this.templateString = htmlTemplate;
            _this.onPostLoad = _this.loaded;
            return _this;
        }
        frmHazmatReport.prototype.bindings = function () {
            this.bind("cmdMoreChemicals_Click", this.cmdMoreChemicals_Click);
            this.bind("cmdSave_Click", this.cmdSave_Click);
            this.bind("cboIncidentType_SelectionChangeCommitted", this.cboIncidentType_SelectionChangeCommitted);
            this.bind("cboIncidentType_Leave", this.cboIncidentType_Leave);
            this.bind("cboHazmatIDSource_SelectionChangeCommitted", this.cboHazmatIDSource_SelectionChangeCommitted);
            this.bind("cboHazmatIDSource_Leave", this.cboHazmatIDSource_Leave);
            this.bind("cboDisposition_SelectionChangeCommitted", this.cboDisposition_SelectionChangeCommitted);
            this.bind("cboDisposition_Leave", this.cboDisposition_Leave);
            this.bind("cboOutsideResource_SelectionChangeCommitted", this.cboOutsideResource_SelectionChangeCommitted);
            this.bind("cboOutsideResource_Leave", this.cboOutsideResource_Leave);
            this.bind("cboResourceUse_SelectionChangeCommitted", this.cboResourceUse_SelectionChangeCommitted);
            this.bind("cboResourceUse_Leave", this.cboResourceUse_Leave);
            this.bind("cmdAddResource_Click", this.cmdAddResource_Click);
            this.bind("cmdRemoveResource_Click", this.cmdRemoveResource_Click);
            this.bind("cboGeneralPropertyUse_SelectionChangeCommitted", this.cboGeneralPropertyUse_SelectionChangeCommitted);
            this.bind("cboGeneralPropertyUse_Leave", this.cboGeneralPropertyUse_Leave);
            this.bind("cboSpecificPropertyUse_SelectionChangeCommitted", this.cboSpecificPropertyUse_SelectionChangeCommitted);
            this.bind("cboSpecificPropertyUse_Leave", this.cboSpecificPropertyUse_Leave);
            this.bind("cboAreaOfOrigin_SelectionChangeCommitted", this.cboAreaOfOrigin_SelectionChangeCommitted);
            this.bind("cboAreaOfOrigin_Leave", this.cboAreaOfOrigin_Leave);
            this.bind("cboCauseOfRelease_SelectionChangeCommitted", this.cboCauseOfRelease_SelectionChangeCommitted);
            this.bind("cboCauseOfRelease_Leave", this.cboCauseOfRelease_Leave);
            this.bind("cboStreetClass_Leave", this.cboStreetClass_Leave);
            this.bind("cboAreaAffectedUnits_SelectionChangeCommitted", this.cboAreaAffectedUnits_SelectionChangeCommitted);
            this.bind("cboAreaAffectedUnits_Leave", this.cboAreaAffectedUnits_Leave);
            this.bind("txtAreaAffected_TextChanged", this.txtAreaAffected_TextChanged);
            this.bind("cboAreaEvacuatedUnits_Leave", this.cboAreaEvacuatedUnits_Leave);
            this.bind("cboPopulationDensity_SelectionChangeCommitted", this.cboPopulationDensity_SelectionChangeCommitted);
            this.bind("cboPopulationDensity_Leave", this.cboPopulationDensity_Leave);
            this.bind("cboSelectChemical_SelectionChangeCommitted", this.cboSelectChemical_SelectionChangeCommitted);
            this.bind("cboSelectChemical_Leave", this.cboSelectChemical_Leave);
            this.bind("cboCommonChemicals_SelectionChangeCommitted", this.cboCommonChemicals_SelectionChangeCommitted);
            this.bind("cboCommonChemicals_Leave", this.cboCommonChemicals_Leave);
            this.bind("cboChemicalName_SelectionChangeCommitted", this.cboChemicalName_SelectionChangeCommitted);
            this.bind("cboChemicalName_Leave", this.cboChemicalName_Leave);
            this.bind("cboUN_SelectionChangeCommitted", this.cboUN_SelectionChangeCommitted);
            this.bind("cboUN_Leave", this.cboUN_Leave);
            this.bind("cboContainerType_SelectionChangeCommitted", this.cboContainerType_SelectionChangeCommitted);
            this.bind("cboContainerType_Leave", this.cboContainerType_Leave);
            this.bind("cboContainerCapacityUnits_SelectionChangeCommitted", this.cboContainerCapacityUnits_SelectionChangeCommitted);
            this.bind("cboContainerCapacityUnits_Leave", this.cboContainerCapacityUnits_Leave);
            this.bind("txtEstContainerCapacity_TextChanged", this.txtEstContainerCapacity_TextChanged);
            this.bind("cboAmountReleasedUnits_SelectionChangeCommitted", this.cboAmountReleasedUnits_SelectionChangeCommitted);
            this.bind("cboAmountReleasedUnits_Leave", this.cboAmountReleasedUnits_Leave);
            this.bind("txtEstAmountReleased_TextChanged", this.txtEstAmountReleased_TextChanged);
            this.bind("cboPhysicalStateStored_SelectionChangeCommitted", this.cboPhysicalStateStored_SelectionChangeCommitted);
            this.bind("cboPhysicalStateStored_Leave", this.cboPhysicalStateStored_Leave);
            this.bind("cboPhysicalStateReleased_SelectionChangeCommitted", this.cboPhysicalStateReleased_SelectionChangeCommitted);
            this.bind("cboPhysicalStateReleased_Leave", this.cboPhysicalStateReleased_Leave);
            this.bind("cboPrimaryReleasedInto_SelectionChangeCommitted", this.cboPrimaryReleasedInto_SelectionChangeCommitted);
            this.bind("cboPrimaryReleasedInto_Leave", this.cboPrimaryReleasedInto_Leave);
            this.bind("cboSecondaryReleasedInto_SelectionChangeCommitted", this.cboSecondaryReleasedInto_SelectionChangeCommitted);
            this.bind("cboSecondaryReleasedInto_Leave", this.cboSecondaryReleasedInto_Leave);
            this.bind("cboDrugLabType_SelectionChangeCommitted", this.cboDrugLabType_SelectionChangeCommitted);
            this.bind("cboDrugLabType_Leave", this.cboDrugLabType_Leave);
            this.bind("cboMaterialUsed_Leave", this.cboMaterialUsed_Leave);
            this.bind("txtQuantity_TextChanged", this.txtQuantity_TextChanged);
            this.bind("cmdAddMaterial_Click", this.cmdAddMaterial_Click);
            this.bind("cmdRemoveMaterial_Click", this.cmdRemoveMaterial_Click);
            this.bind("cboNarrList_SelectionChangeCommitted", this.cboNarrList_SelectionChangeCommitted);
            this.bind("cmdAddNarration_Click", this.cmdAddNarration_Click);
            //this.bindCloseEvent();
        };
        Object.defineProperty(frmHazmatReport.prototype, "name", {
            get: function () {
                return "frmHazmatReport";
            },
            enumerable: true,
            configurable: true
        });
        frmHazmatReport.prototype.loaded = function () {
        };
        frmHazmatReport.prototype.frmHazmatReport_Close = function (e) {
            if (e.userTriggered) {
                window.app.sendAction({ mainobj: this, controller: "frmHazmatReport", action: "frmHazmatReport_Close" });
                e.preventDefault();
            }
        };
        frmHazmatReport.prototype.cmdMoreChemicals_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmHazmatReport.prototype.cmdSave_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        frmHazmatReport.prototype.cboIncidentType_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmHazmatReport.prototype.cboIncidentType_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmHazmatReport.prototype.cboHazmatIDSource_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmHazmatReport.prototype.cboHazmatIDSource_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmHazmatReport.prototype.cboDisposition_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmHazmatReport.prototype.cboDisposition_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmHazmatReport.prototype.cboOutsideResource_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmHazmatReport.prototype.cboOutsideResource_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmHazmatReport.prototype.cboResourceUse_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmHazmatReport.prototype.cboResourceUse_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmHazmatReport.prototype.cmdAddResource_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmHazmatReport.prototype.cmdRemoveResource_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmHazmatReport.prototype.cboGeneralPropertyUse_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmHazmatReport.prototype.cboGeneralPropertyUse_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmHazmatReport.prototype.cboSpecificPropertyUse_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmHazmatReport.prototype.cboSpecificPropertyUse_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmHazmatReport.prototype.cboAreaOfOrigin_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmHazmatReport.prototype.cboAreaOfOrigin_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmHazmatReport.prototype.cboCauseOfRelease_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmHazmatReport.prototype.cboCauseOfRelease_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmHazmatReport.prototype.cboStreetClass_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmHazmatReport.prototype.cboAreaAffectedUnits_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmHazmatReport.prototype.cboAreaAffectedUnits_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmHazmatReport.prototype.txtAreaAffected_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmHazmatReport.prototype.cboAreaEvacuatedUnits_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmHazmatReport.prototype.cboPopulationDensity_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmHazmatReport.prototype.cboPopulationDensity_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmHazmatReport.prototype.cboSelectChemical_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmHazmatReport.prototype.cboSelectChemical_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmHazmatReport.prototype.cboCommonChemicals_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmHazmatReport.prototype.cboCommonChemicals_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmHazmatReport.prototype.cboChemicalName_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmHazmatReport.prototype.cboChemicalName_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmHazmatReport.prototype.cboUN_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmHazmatReport.prototype.cboUN_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmHazmatReport.prototype.cboContainerType_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmHazmatReport.prototype.cboContainerType_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmHazmatReport.prototype.cboContainerCapacityUnits_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmHazmatReport.prototype.cboContainerCapacityUnits_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmHazmatReport.prototype.txtEstContainerCapacity_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmHazmatReport.prototype.cboAmountReleasedUnits_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmHazmatReport.prototype.cboAmountReleasedUnits_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmHazmatReport.prototype.txtEstAmountReleased_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmHazmatReport.prototype.cboPhysicalStateStored_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmHazmatReport.prototype.cboPhysicalStateStored_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmHazmatReport.prototype.cboPhysicalStateReleased_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmHazmatReport.prototype.cboPhysicalStateReleased_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmHazmatReport.prototype.cboPrimaryReleasedInto_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmHazmatReport.prototype.cboPrimaryReleasedInto_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmHazmatReport.prototype.cboSecondaryReleasedInto_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmHazmatReport.prototype.cboSecondaryReleasedInto_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmHazmatReport.prototype.cboDrugLabType_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmHazmatReport.prototype.cboDrugLabType_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmHazmatReport.prototype.cboMaterialUsed_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmHazmatReport.prototype.txtQuantity_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmHazmatReport.prototype.cmdAddMaterial_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmHazmatReport.prototype.cmdRemoveMaterial_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmHazmatReport.prototype.cboNarrList_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmHazmatReport.prototype.cmdAddNarration_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        return frmHazmatReport;
    }(Mobilize.WebMap.Kendo.Ui.KendoView));
});
//# sourceMappingURL=TFDIncident.frmHazmatReport.js.map