/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("TFDIncident.frmHazmatReport", [ "files/text!views/TFDIncident.frmHazmatReport.html", "files/css!views/TFDIncident.frmHazmatReport.css"],
    (htmlTemplate) => {
    return class frmHazmatReport extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("cmdMoreChemicals_Click",this.cmdMoreChemicals_Click);
this.bind("cmdSave_Click",this.cmdSave_Click);
this.bind("cboIncidentType_SelectionChangeCommitted",this.cboIncidentType_SelectionChangeCommitted);
this.bind("cboIncidentType_Leave",this.cboIncidentType_Leave);
this.bind("cboHazmatIDSource_SelectionChangeCommitted",this.cboHazmatIDSource_SelectionChangeCommitted);
this.bind("cboHazmatIDSource_Leave",this.cboHazmatIDSource_Leave);
this.bind("cboDisposition_SelectionChangeCommitted",this.cboDisposition_SelectionChangeCommitted);
this.bind("cboDisposition_Leave",this.cboDisposition_Leave);
this.bind("cboOutsideResource_SelectionChangeCommitted",this.cboOutsideResource_SelectionChangeCommitted);
this.bind("cboOutsideResource_Leave",this.cboOutsideResource_Leave);
this.bind("cboResourceUse_SelectionChangeCommitted",this.cboResourceUse_SelectionChangeCommitted);
this.bind("cboResourceUse_Leave",this.cboResourceUse_Leave);
this.bind("cmdAddResource_Click",this.cmdAddResource_Click);
this.bind("cmdRemoveResource_Click",this.cmdRemoveResource_Click);
this.bind("cboGeneralPropertyUse_SelectionChangeCommitted",this.cboGeneralPropertyUse_SelectionChangeCommitted);
this.bind("cboGeneralPropertyUse_Leave",this.cboGeneralPropertyUse_Leave);
this.bind("cboSpecificPropertyUse_SelectionChangeCommitted",this.cboSpecificPropertyUse_SelectionChangeCommitted);
this.bind("cboSpecificPropertyUse_Leave",this.cboSpecificPropertyUse_Leave);
this.bind("cboAreaOfOrigin_SelectionChangeCommitted",this.cboAreaOfOrigin_SelectionChangeCommitted);
this.bind("cboAreaOfOrigin_Leave",this.cboAreaOfOrigin_Leave);
this.bind("cboCauseOfRelease_SelectionChangeCommitted",this.cboCauseOfRelease_SelectionChangeCommitted);
this.bind("cboCauseOfRelease_Leave",this.cboCauseOfRelease_Leave);
this.bind("cboStreetClass_Leave",this.cboStreetClass_Leave);
this.bind("cboAreaAffectedUnits_SelectionChangeCommitted",this.cboAreaAffectedUnits_SelectionChangeCommitted);
this.bind("cboAreaAffectedUnits_Leave",this.cboAreaAffectedUnits_Leave);
this.bind("txtAreaAffected_TextChanged",this.txtAreaAffected_TextChanged);
this.bind("cboAreaEvacuatedUnits_Leave",this.cboAreaEvacuatedUnits_Leave);
this.bind("cboPopulationDensity_SelectionChangeCommitted",this.cboPopulationDensity_SelectionChangeCommitted);
this.bind("cboPopulationDensity_Leave",this.cboPopulationDensity_Leave);
this.bind("cboSelectChemical_SelectionChangeCommitted",this.cboSelectChemical_SelectionChangeCommitted);
this.bind("cboSelectChemical_Leave",this.cboSelectChemical_Leave);
this.bind("cboCommonChemicals_SelectionChangeCommitted",this.cboCommonChemicals_SelectionChangeCommitted);
this.bind("cboCommonChemicals_Leave",this.cboCommonChemicals_Leave);
this.bind("cboChemicalName_SelectionChangeCommitted",this.cboChemicalName_SelectionChangeCommitted);
this.bind("cboChemicalName_Leave",this.cboChemicalName_Leave);
this.bind("cboUN_SelectionChangeCommitted",this.cboUN_SelectionChangeCommitted);
this.bind("cboUN_Leave",this.cboUN_Leave);
this.bind("cboContainerType_SelectionChangeCommitted",this.cboContainerType_SelectionChangeCommitted);
this.bind("cboContainerType_Leave",this.cboContainerType_Leave);
this.bind("cboContainerCapacityUnits_SelectionChangeCommitted",this.cboContainerCapacityUnits_SelectionChangeCommitted);
this.bind("cboContainerCapacityUnits_Leave",this.cboContainerCapacityUnits_Leave);
this.bind("txtEstContainerCapacity_TextChanged",this.txtEstContainerCapacity_TextChanged);
this.bind("cboAmountReleasedUnits_SelectionChangeCommitted",this.cboAmountReleasedUnits_SelectionChangeCommitted);
this.bind("cboAmountReleasedUnits_Leave",this.cboAmountReleasedUnits_Leave);
this.bind("txtEstAmountReleased_TextChanged",this.txtEstAmountReleased_TextChanged);
this.bind("cboPhysicalStateStored_SelectionChangeCommitted",this.cboPhysicalStateStored_SelectionChangeCommitted);
this.bind("cboPhysicalStateStored_Leave",this.cboPhysicalStateStored_Leave);
this.bind("cboPhysicalStateReleased_SelectionChangeCommitted",this.cboPhysicalStateReleased_SelectionChangeCommitted);
this.bind("cboPhysicalStateReleased_Leave",this.cboPhysicalStateReleased_Leave);
this.bind("cboPrimaryReleasedInto_SelectionChangeCommitted",this.cboPrimaryReleasedInto_SelectionChangeCommitted);
this.bind("cboPrimaryReleasedInto_Leave",this.cboPrimaryReleasedInto_Leave);
this.bind("cboSecondaryReleasedInto_SelectionChangeCommitted",this.cboSecondaryReleasedInto_SelectionChangeCommitted);
this.bind("cboSecondaryReleasedInto_Leave",this.cboSecondaryReleasedInto_Leave);
this.bind("cboDrugLabType_SelectionChangeCommitted",this.cboDrugLabType_SelectionChangeCommitted);
this.bind("cboDrugLabType_Leave",this.cboDrugLabType_Leave);
this.bind("cboMaterialUsed_Leave",this.cboMaterialUsed_Leave);
this.bind("txtQuantity_TextChanged",this.txtQuantity_TextChanged);
this.bind("cmdAddMaterial_Click",this.cmdAddMaterial_Click);
this.bind("cmdRemoveMaterial_Click",this.cmdRemoveMaterial_Click);
this.bind("cboNarrList_SelectionChangeCommitted",this.cboNarrList_SelectionChangeCommitted);
this.bind("cmdAddNarration_Click",this.cmdAddNarration_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmHazmatReport";
            }

            public loaded() {
			
            }

        

        public frmHazmatReport_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmHazmatReport",action:"frmHazmatReport_Close"});
                e.preventDefault();
            }
            
        }
        public cmdMoreChemicals_Click(sender: frmHazmatReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdSave_Click(sender: frmHazmatReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public cboIncidentType_SelectionChangeCommitted(sender: frmHazmatReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboIncidentType_Leave(sender: frmHazmatReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboHazmatIDSource_SelectionChangeCommitted(sender: frmHazmatReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboHazmatIDSource_Leave(sender: frmHazmatReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboDisposition_SelectionChangeCommitted(sender: frmHazmatReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboDisposition_Leave(sender: frmHazmatReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboOutsideResource_SelectionChangeCommitted(sender: frmHazmatReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboOutsideResource_Leave(sender: frmHazmatReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboResourceUse_SelectionChangeCommitted(sender: frmHazmatReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboResourceUse_Leave(sender: frmHazmatReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdAddResource_Click(sender: frmHazmatReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdRemoveResource_Click(sender: frmHazmatReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboGeneralPropertyUse_SelectionChangeCommitted(sender: frmHazmatReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboGeneralPropertyUse_Leave(sender: frmHazmatReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboSpecificPropertyUse_SelectionChangeCommitted(sender: frmHazmatReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboSpecificPropertyUse_Leave(sender: frmHazmatReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboAreaOfOrigin_SelectionChangeCommitted(sender: frmHazmatReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboAreaOfOrigin_Leave(sender: frmHazmatReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboCauseOfRelease_SelectionChangeCommitted(sender: frmHazmatReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboCauseOfRelease_Leave(sender: frmHazmatReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboStreetClass_Leave(sender: frmHazmatReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboAreaAffectedUnits_SelectionChangeCommitted(sender: frmHazmatReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboAreaAffectedUnits_Leave(sender: frmHazmatReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtAreaAffected_TextChanged(sender: frmHazmatReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboAreaEvacuatedUnits_Leave(sender: frmHazmatReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboPopulationDensity_SelectionChangeCommitted(sender: frmHazmatReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboPopulationDensity_Leave(sender: frmHazmatReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboSelectChemical_SelectionChangeCommitted(sender: frmHazmatReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboSelectChemical_Leave(sender: frmHazmatReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboCommonChemicals_SelectionChangeCommitted(sender: frmHazmatReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboCommonChemicals_Leave(sender: frmHazmatReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboChemicalName_SelectionChangeCommitted(sender: frmHazmatReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboChemicalName_Leave(sender: frmHazmatReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboUN_SelectionChangeCommitted(sender: frmHazmatReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboUN_Leave(sender: frmHazmatReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboContainerType_SelectionChangeCommitted(sender: frmHazmatReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboContainerType_Leave(sender: frmHazmatReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboContainerCapacityUnits_SelectionChangeCommitted(sender: frmHazmatReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboContainerCapacityUnits_Leave(sender: frmHazmatReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtEstContainerCapacity_TextChanged(sender: frmHazmatReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboAmountReleasedUnits_SelectionChangeCommitted(sender: frmHazmatReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboAmountReleasedUnits_Leave(sender: frmHazmatReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtEstAmountReleased_TextChanged(sender: frmHazmatReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboPhysicalStateStored_SelectionChangeCommitted(sender: frmHazmatReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboPhysicalStateStored_Leave(sender: frmHazmatReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboPhysicalStateReleased_SelectionChangeCommitted(sender: frmHazmatReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboPhysicalStateReleased_Leave(sender: frmHazmatReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboPrimaryReleasedInto_SelectionChangeCommitted(sender: frmHazmatReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboPrimaryReleasedInto_Leave(sender: frmHazmatReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboSecondaryReleasedInto_SelectionChangeCommitted(sender: frmHazmatReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboSecondaryReleasedInto_Leave(sender: frmHazmatReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboDrugLabType_SelectionChangeCommitted(sender: frmHazmatReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboDrugLabType_Leave(sender: frmHazmatReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboMaterialUsed_Leave(sender: frmHazmatReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtQuantity_TextChanged(sender: frmHazmatReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdAddMaterial_Click(sender: frmHazmatReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdRemoveMaterial_Click(sender: frmHazmatReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboNarrList_SelectionChangeCommitted(sender: frmHazmatReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdAddNarration_Click(sender: frmHazmatReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

