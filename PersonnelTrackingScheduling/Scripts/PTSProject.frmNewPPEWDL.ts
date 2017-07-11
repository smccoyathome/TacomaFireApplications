/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmNewPPEWDL", [ "files/text!views/PTSProject.frmNewPPEWDL.html", "files/css!views/PTSProject.frmNewPPEWDL.css"],
    (htmlTemplate) => {
    return class frmNewPPEWDL extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("opt181_CheckedChanged",this.opt181_CheckedChanged);
this.bind("opt183_CheckedChanged",this.opt183_CheckedChanged);
this.bind("opt182_CheckedChanged",this.opt182_CheckedChanged);
this.bind("optAll_CheckedChanged",this.optAll_CheckedChanged);
this.bind("optA_CheckedChanged",this.optA_CheckedChanged);
this.bind("optC_CheckedChanged",this.optC_CheckedChanged);
this.bind("optB_CheckedChanged",this.optB_CheckedChanged);
this.bind("optD_CheckedChanged",this.optD_CheckedChanged);
this.bind("cmdClose_Click",this.cmdClose_Click);
this.bind("cmdPrintChecklist_Click",this.cmdPrintChecklist_Click);
this.bind("chkInactive_CheckStateChanged",this.chkInactive_CheckStateChanged);
this.bind("cboEmpList_SelectionChangeCommitted",this.cboEmpList_SelectionChangeCommitted);
this.bind("cmdSearch_Click",this.cmdSearch_Click);
this.bind("cmdSizes_Click",this.cmdSizes_Click);
this.bind("cmdUniformQuery_Click",this.cmdUniformQuery_Click);
this.bind("cmdGlobe_Click",this.cmdGlobe_Click);
this.bind("cmdUpdateWDL_Click",this.cmdUpdateWDL_Click);
this.bind("cmdLaundryMgmt_Click",this.cmdLaundryMgmt_Click);
this.bind("cmdUniformInventory_Click",this.cmdUniformInventory_Click);
this.bind("cmdLastInsp_Click",this.cmdLastInsp_Click);
this.bind("cmdInspection_Click",this.cmdInspection_Click);
this.bind("cmdRepair_Click",this.cmdRepair_Click);
this.bind("cmdCleaning_Click",this.cmdCleaning_Click);
this.bind("dtInspection_Click",this.dtInspection_Click);
this.bind("dtInspection_ValueChanged",this.dtInspection_ValueChanged);
this.bind("cmdAllOK_Click",this.cmdAllOK_Click);
this.bind("cmdAddNew_Click",this.cmdAddNew_Click);
this.bind("cmdNewItem_Click",this.cmdNewItem_Click);
this.bind("cmdEditItem_Click",this.cmdEditItem_Click);
this.bind("cmdFind_Click",this.cmdFind_Click);
this.bind("cmdReplaceItem_Click",this.cmdReplaceItem_Click);
this.bind("cboItemType_SelectionChangeCommitted",this.cboItemType_SelectionChangeCommitted);
this.bind("chkManufDate_CheckStateChanged",this.chkManufDate_CheckStateChanged);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmNewPPEWDL";
            }

            public loaded() {

            }

        

        public frmNewPPEWDL_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmNewPPEWDL",action:"frmNewPPEWDL_Close"});
                e.preventDefault();
            }
            
        }
        public opt181_CheckedChanged(sender: frmNewPPEWDL, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public opt183_CheckedChanged(sender: frmNewPPEWDL, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public opt182_CheckedChanged(sender: frmNewPPEWDL, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public optAll_CheckedChanged(sender: frmNewPPEWDL, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public optA_CheckedChanged(sender: frmNewPPEWDL, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public optC_CheckedChanged(sender: frmNewPPEWDL, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public optB_CheckedChanged(sender: frmNewPPEWDL, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public optD_CheckedChanged(sender: frmNewPPEWDL, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClose_Click(sender: frmNewPPEWDL, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdPrintChecklist_Click(sender: frmNewPPEWDL, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public chkInactive_CheckStateChanged(sender: frmNewPPEWDL, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboEmpList_SelectionChangeCommitted(sender: frmNewPPEWDL, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdSearch_Click(sender: frmNewPPEWDL, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdSizes_Click(sender: frmNewPPEWDL, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdUniformQuery_Click(sender: frmNewPPEWDL, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdGlobe_Click(sender: frmNewPPEWDL, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdUpdateWDL_Click(sender: frmNewPPEWDL, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdLaundryMgmt_Click(sender: frmNewPPEWDL, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdUniformInventory_Click(sender: frmNewPPEWDL, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
            public loadSpread(name: string) {
                var uniqueId = this.model.UniqueID;
                require(["spread"], (spread) => {
                    spread(name, uniqueId);
                });
            }
        public cmdLastInsp_Click(sender: frmNewPPEWDL, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdInspection_Click(sender: frmNewPPEWDL, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdRepair_Click(sender: frmNewPPEWDL, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdCleaning_Click(sender: frmNewPPEWDL, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public dtInspection_Click(sender: frmNewPPEWDL, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public dtInspection_ValueChanged(sender: frmNewPPEWDL, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdAllOK_Click(sender: frmNewPPEWDL, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdAddNew_Click(sender: frmNewPPEWDL, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdNewItem_Click(sender: frmNewPPEWDL, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdEditItem_Click(sender: frmNewPPEWDL, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdFind_Click(sender: frmNewPPEWDL, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdReplaceItem_Click(sender: frmNewPPEWDL, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboItemType_SelectionChangeCommitted(sender: frmNewPPEWDL, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public chkManufDate_CheckStateChanged(sender: frmNewPPEWDL, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

