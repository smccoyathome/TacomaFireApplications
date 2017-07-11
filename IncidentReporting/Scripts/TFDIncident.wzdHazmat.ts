/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("TFDIncident.wzdHazmat", [ "files/text!views/TFDIncident.wzdHazmat.html", "files/css!views/TFDIncident.wzdHazmat.css","usercontrols/UpgradeHelpers_Gui_ShapeHelper"],
    (htmlTemplate) => {
    return class wzdHazmat extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("optType_CheckedChanged",this.optType_CheckedChanged);
this.bind("cboHazmatIDSource_SelectionChangeCommitted",this.cboHazmatIDSource_SelectionChangeCommitted);
this.bind("cmdSave_Click",this.cmdSave_Click);
this.bind("cmdSaveIncomplete_Click",this.cmdSaveIncomplete_Click);
this.bind("cmdAbandon_Click",this.cmdAbandon_Click);
this.bind("cboDisposition_SelectionChangeCommitted",this.cboDisposition_SelectionChangeCommitted);
this.bind("cboOutsideResource_SelectionChangeCommitted",this.cboOutsideResource_SelectionChangeCommitted);
this.bind("cboResourceUse_SelectionChangeCommitted",this.cboResourceUse_SelectionChangeCommitted);
this.bind("cmdAddResource_Click",this.cmdAddResource_Click);
this.bind("cmdRemoveResource_Click",this.cmdRemoveResource_Click);
this.bind("cboDrugLabType_SelectionChangeCommitted",this.cboDrugLabType_SelectionChangeCommitted);
this.bind("cboMaterialUsed_SelectionChangeCommitted",this.cboMaterialUsed_SelectionChangeCommitted);
this.bind("txtQuantity_TextChanged",this.txtQuantity_TextChanged);
this.bind("cmdAddMaterial_Click",this.cmdAddMaterial_Click);
this.bind("cmdRemoveMaterial_Click",this.cmdRemoveMaterial_Click);
this.bind("cboCommonChemicals_SelectionChangeCommitted",this.cboCommonChemicals_SelectionChangeCommitted);
this.bind("cboChemicalName_SelectionChangeCommitted",this.cboChemicalName_SelectionChangeCommitted);
this.bind("cboUN_SelectionChangeCommitted",this.cboUN_SelectionChangeCommitted);
this.bind("cboPhysicalStateStored_SelectionChangeCommitted",this.cboPhysicalStateStored_SelectionChangeCommitted);
this.bind("cboContainerType_SelectionChangeCommitted",this.cboContainerType_SelectionChangeCommitted);
this.bind("cboPhysicalStateReleased_SelectionChangeCommitted",this.cboPhysicalStateReleased_SelectionChangeCommitted);
this.bind("cboContainerCapacityUnits_SelectionChangeCommitted",this.cboContainerCapacityUnits_SelectionChangeCommitted);
this.bind("txtEstContainerCapacity_TextChanged",this.txtEstContainerCapacity_TextChanged);
this.bind("cboPrimaryReleasedInto_SelectionChangeCommitted",this.cboPrimaryReleasedInto_SelectionChangeCommitted);
this.bind("cboAmountReleasedUnits_SelectionChangeCommitted",this.cboAmountReleasedUnits_SelectionChangeCommitted);
this.bind("txtEstAmountReleased_TextChanged",this.txtEstAmountReleased_TextChanged);
this.bind("cmdMoreChemicals_Click",this.cmdMoreChemicals_Click);
this.bind("cboIncidentType_SelectionChangeCommitted",this.cboIncidentType_SelectionChangeCommitted);
this.bind("cboGeneralPropertyUse_SelectionChangeCommitted", this.cboGeneralPropertyUse_SelectionChangeCommitted);

this.bind("cboAreaAffectedUnits_SelectionChangeCommitted",this.cboAreaAffectedUnits_SelectionChangeCommitted);
this.bind("cboSpecificPropertyUse_SelectionChangeCommitted",this.cboSpecificPropertyUse_SelectionChangeCommitted);
this.bind("txtAreaAffected_TextChanged",this.txtAreaAffected_TextChanged);
this.bind("cboAreaOfOrigin_SelectionChangeCommitted",this.cboAreaOfOrigin_SelectionChangeCommitted);
this.bind("cboAreaEvacuatedUnits_SelectionChangeCommitted",this.cboAreaEvacuatedUnits_SelectionChangeCommitted);
this.bind("txtAreaEvacuated_TextChanged",this.txtAreaEvacuated_TextChanged);
this.bind("cboCauseOfRelease_SelectionChangeCommitted",this.cboCauseOfRelease_SelectionChangeCommitted);
this.bind("txtReleaseFloor_TextChanged",this.txtReleaseFloor_TextChanged);
this.bind("cboPopulationDensity_SelectionChangeCommitted",this.cboPopulationDensity_SelectionChangeCommitted);
this.bind("txtPeopleEvacuated_TextChanged",this.txtPeopleEvacuated_TextChanged);
this.bind("txtBuildingsEvacuated_TextChanged",this.txtBuildingsEvacuated_TextChanged);
this.bind("NavButton_Click",this.NavButton_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "wzdHazmat";
            }

            public loaded() {
			
            }

        

        public wzdHazmat_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"wzdHazmat",action:"wzdHazmat_Close"});
                e.preventDefault();
            }
            
        }
        public optType_CheckedChanged(sender: wzdHazmat, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public cboHazmatIDSource_SelectionChangeCommitted(sender: wzdHazmat, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdSave_Click(sender: wzdHazmat, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdSaveIncomplete_Click(sender: wzdHazmat, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdAbandon_Click(sender: wzdHazmat, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboDisposition_SelectionChangeCommitted(sender: wzdHazmat, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboOutsideResource_SelectionChangeCommitted(sender: wzdHazmat, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboResourceUse_SelectionChangeCommitted(sender: wzdHazmat, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdAddResource_Click(sender: wzdHazmat, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdRemoveResource_Click(sender: wzdHazmat, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboDrugLabType_SelectionChangeCommitted(sender: wzdHazmat, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboMaterialUsed_SelectionChangeCommitted(sender: wzdHazmat, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtQuantity_TextChanged(sender: wzdHazmat, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdAddMaterial_Click(sender: wzdHazmat, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdRemoveMaterial_Click(sender: wzdHazmat, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboCommonChemicals_SelectionChangeCommitted(sender: wzdHazmat, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboChemicalName_SelectionChangeCommitted(sender: wzdHazmat, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboUN_SelectionChangeCommitted(sender: wzdHazmat, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboPhysicalStateStored_SelectionChangeCommitted(sender: wzdHazmat, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboContainerType_SelectionChangeCommitted(sender: wzdHazmat, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboPhysicalStateReleased_SelectionChangeCommitted(sender: wzdHazmat, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboContainerCapacityUnits_SelectionChangeCommitted(sender: wzdHazmat, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtEstContainerCapacity_TextChanged(sender: wzdHazmat, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboPrimaryReleasedInto_SelectionChangeCommitted(sender: wzdHazmat, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboAmountReleasedUnits_SelectionChangeCommitted(sender: wzdHazmat, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtEstAmountReleased_TextChanged(sender: wzdHazmat, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdMoreChemicals_Click(sender: wzdHazmat, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboIncidentType_SelectionChangeCommitted(sender: wzdHazmat, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboGeneralPropertyUse_SelectionChangeCommitted(sender: wzdHazmat, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

        public cboAreaAffectedUnits_SelectionChangeCommitted(sender: wzdHazmat, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboSpecificPropertyUse_SelectionChangeCommitted(sender: wzdHazmat, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtAreaAffected_TextChanged(sender: wzdHazmat, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboAreaOfOrigin_SelectionChangeCommitted(sender: wzdHazmat, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboAreaEvacuatedUnits_SelectionChangeCommitted(sender: wzdHazmat, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtAreaEvacuated_TextChanged(sender: wzdHazmat, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboCauseOfRelease_SelectionChangeCommitted(sender: wzdHazmat, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtReleaseFloor_TextChanged(sender: wzdHazmat, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboPopulationDensity_SelectionChangeCommitted(sender: wzdHazmat, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtPeopleEvacuated_TextChanged(sender: wzdHazmat, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtBuildingsEvacuated_TextChanged(sender: wzdHazmat, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public NavButton_Click(sender: wzdHazmat, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }

    }
   
});

