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
define("TFDIncident.wzdHazmat", ["files/text!views/TFDIncident.wzdHazmat.html", "files/css!views/TFDIncident.wzdHazmat.css", "usercontrols/UpgradeHelpers_Gui_ShapeHelper"], function (htmlTemplate) {
    return (function (_super) {
        __extends(wzdHazmat, _super);
        function wzdHazmat(model) {
            var _this = _super.call(this, model) || this;
            _this.templateString = htmlTemplate;
            _this.onPostLoad = _this.loaded;
            return _this;
        }
        wzdHazmat.prototype.bindings = function () {
            this.bind("optType_CheckedChanged", this.optType_CheckedChanged);
            this.bind("cboHazmatIDSource_SelectionChangeCommitted", this.cboHazmatIDSource_SelectionChangeCommitted);
            this.bind("cmdSave_Click", this.cmdSave_Click);
            this.bind("cmdSaveIncomplete_Click", this.cmdSaveIncomplete_Click);
            this.bind("cmdAbandon_Click", this.cmdAbandon_Click);
            this.bind("cboDisposition_SelectionChangeCommitted", this.cboDisposition_SelectionChangeCommitted);
            this.bind("cboOutsideResource_SelectionChangeCommitted", this.cboOutsideResource_SelectionChangeCommitted);
            this.bind("cboResourceUse_SelectionChangeCommitted", this.cboResourceUse_SelectionChangeCommitted);
            this.bind("cmdAddResource_Click", this.cmdAddResource_Click);
            this.bind("cmdRemoveResource_Click", this.cmdRemoveResource_Click);
            this.bind("cboDrugLabType_SelectionChangeCommitted", this.cboDrugLabType_SelectionChangeCommitted);
            this.bind("cboMaterialUsed_SelectionChangeCommitted", this.cboMaterialUsed_SelectionChangeCommitted);
            this.bind("txtQuantity_TextChanged", this.txtQuantity_TextChanged);
            this.bind("cmdAddMaterial_Click", this.cmdAddMaterial_Click);
            this.bind("cmdRemoveMaterial_Click", this.cmdRemoveMaterial_Click);
            this.bind("cboCommonChemicals_SelectionChangeCommitted", this.cboCommonChemicals_SelectionChangeCommitted);
            this.bind("cboChemicalName_SelectionChangeCommitted", this.cboChemicalName_SelectionChangeCommitted);
            this.bind("cboUN_SelectionChangeCommitted", this.cboUN_SelectionChangeCommitted);
            this.bind("cboPhysicalStateStored_SelectionChangeCommitted", this.cboPhysicalStateStored_SelectionChangeCommitted);
            this.bind("cboContainerType_SelectionChangeCommitted", this.cboContainerType_SelectionChangeCommitted);
            this.bind("cboPhysicalStateReleased_SelectionChangeCommitted", this.cboPhysicalStateReleased_SelectionChangeCommitted);
            this.bind("cboContainerCapacityUnits_SelectionChangeCommitted", this.cboContainerCapacityUnits_SelectionChangeCommitted);
            this.bind("txtEstContainerCapacity_TextChanged", this.txtEstContainerCapacity_TextChanged);
            this.bind("cboPrimaryReleasedInto_SelectionChangeCommitted", this.cboPrimaryReleasedInto_SelectionChangeCommitted);
            this.bind("cboAmountReleasedUnits_SelectionChangeCommitted", this.cboAmountReleasedUnits_SelectionChangeCommitted);
            this.bind("txtEstAmountReleased_TextChanged", this.txtEstAmountReleased_TextChanged);
            this.bind("cmdMoreChemicals_Click", this.cmdMoreChemicals_Click);
            this.bind("cboIncidentType_SelectionChangeCommitted", this.cboIncidentType_SelectionChangeCommitted);
            this.bind("cboGeneralPropertyUse_SelectionChangeCommitted", this.cboGeneralPropertyUse_SelectionChangeCommitted);
            this.bind("cboAreaAffectedUnits_SelectionChangeCommitted", this.cboAreaAffectedUnits_SelectionChangeCommitted);
            this.bind("cboSpecificPropertyUse_SelectionChangeCommitted", this.cboSpecificPropertyUse_SelectionChangeCommitted);
            this.bind("txtAreaAffected_TextChanged", this.txtAreaAffected_TextChanged);
            this.bind("cboAreaOfOrigin_SelectionChangeCommitted", this.cboAreaOfOrigin_SelectionChangeCommitted);
            this.bind("cboAreaEvacuatedUnits_SelectionChangeCommitted", this.cboAreaEvacuatedUnits_SelectionChangeCommitted);
            this.bind("txtAreaEvacuated_TextChanged", this.txtAreaEvacuated_TextChanged);
            this.bind("cboCauseOfRelease_SelectionChangeCommitted", this.cboCauseOfRelease_SelectionChangeCommitted);
            this.bind("txtReleaseFloor_TextChanged", this.txtReleaseFloor_TextChanged);
            this.bind("cboPopulationDensity_SelectionChangeCommitted", this.cboPopulationDensity_SelectionChangeCommitted);
            this.bind("txtPeopleEvacuated_TextChanged", this.txtPeopleEvacuated_TextChanged);
            this.bind("txtBuildingsEvacuated_TextChanged", this.txtBuildingsEvacuated_TextChanged);
            this.bind("NavButton_Click", this.NavButton_Click);
            //this.bindCloseEvent();
        };
        Object.defineProperty(wzdHazmat.prototype, "name", {
            get: function () {
                return "wzdHazmat";
            },
            enumerable: true,
            configurable: true
        });
        wzdHazmat.prototype.loaded = function () {
        };
        wzdHazmat.prototype.wzdHazmat_Close = function (e) {
            if (e.userTriggered) {
                window.app.sendAction({ mainobj: this, controller: "wzdHazmat", action: "wzdHazmat_Close" });
                e.preventDefault();
            }
        };
        wzdHazmat.prototype.optType_CheckedChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        wzdHazmat.prototype.cboHazmatIDSource_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdHazmat.prototype.cmdSave_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdHazmat.prototype.cmdSaveIncomplete_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdHazmat.prototype.cmdAbandon_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdHazmat.prototype.cboDisposition_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdHazmat.prototype.cboOutsideResource_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdHazmat.prototype.cboResourceUse_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdHazmat.prototype.cmdAddResource_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdHazmat.prototype.cmdRemoveResource_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdHazmat.prototype.cboDrugLabType_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdHazmat.prototype.cboMaterialUsed_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdHazmat.prototype.txtQuantity_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdHazmat.prototype.cmdAddMaterial_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdHazmat.prototype.cmdRemoveMaterial_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdHazmat.prototype.cboCommonChemicals_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdHazmat.prototype.cboChemicalName_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdHazmat.prototype.cboUN_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdHazmat.prototype.cboPhysicalStateStored_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdHazmat.prototype.cboContainerType_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdHazmat.prototype.cboPhysicalStateReleased_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdHazmat.prototype.cboContainerCapacityUnits_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdHazmat.prototype.txtEstContainerCapacity_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdHazmat.prototype.cboPrimaryReleasedInto_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdHazmat.prototype.cboAmountReleasedUnits_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdHazmat.prototype.txtEstAmountReleased_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdHazmat.prototype.cmdMoreChemicals_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdHazmat.prototype.cboIncidentType_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdHazmat.prototype.cboGeneralPropertyUse_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdHazmat.prototype.cboAreaAffectedUnits_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdHazmat.prototype.cboSpecificPropertyUse_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdHazmat.prototype.txtAreaAffected_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdHazmat.prototype.cboAreaOfOrigin_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdHazmat.prototype.cboAreaEvacuatedUnits_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdHazmat.prototype.txtAreaEvacuated_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdHazmat.prototype.cboCauseOfRelease_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdHazmat.prototype.txtReleaseFloor_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdHazmat.prototype.cboPopulationDensity_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdHazmat.prototype.txtPeopleEvacuated_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdHazmat.prototype.txtBuildingsEvacuated_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdHazmat.prototype.NavButton_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        return wzdHazmat;
    }(Mobilize.WebMap.Kendo.Ui.KendoView));
});
//# sourceMappingURL=TFDIncident.wzdHazmat.js.map