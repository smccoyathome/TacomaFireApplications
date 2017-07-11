/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmImmunization", [ "files/text!views/PTSProject.frmImmunization.html", "files/css!views/PTSProject.frmImmunization.css"],
    (htmlTemplate) => {
    return class frmImmunization extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("optAll_CheckedChanged",this.optAll_CheckedChanged);
this.bind("opt182_CheckedChanged",this.opt182_CheckedChanged);
this.bind("opt181_CheckedChanged",this.opt181_CheckedChanged);
this.bind("opt183_CheckedChanged",this.opt183_CheckedChanged);
this.bind("optA_CheckedChanged",this.optA_CheckedChanged);
this.bind("optC_CheckedChanged",this.optC_CheckedChanged);
this.bind("optB_CheckedChanged",this.optB_CheckedChanged);
this.bind("optD_CheckedChanged",this.optD_CheckedChanged);
this.bind("cboAssignmentCode_SelectionChangeCommitted",this.cboAssignmentCode_SelectionChangeCommitted);
this.bind("cboUnit_SelectionChangeCommitted",this.cboUnit_SelectionChangeCommitted);
this.bind("cboClose_Click",this.cboClose_Click);
this.bind("txtNameSearch_TextChanged",this.txtNameSearch_TextChanged);
this.bind("chkArchiveOnly_CheckStateChanged",this.chkArchiveOnly_CheckStateChanged);
this.bind("cmdClear_Click",this.cmdClear_Click);
this.bind("cmdAddMuliple_Click",this.cmdAddMuliple_Click);
this.bind("cmdQuery_Click",this.cmdQuery_Click);
this.bind("cmdPrintReport_Click",this.cmdPrintReport_Click);
this.bind("chkImmuneDate_CheckStateChanged",this.chkImmuneDate_CheckStateChanged);
this.bind("cmdNewRecord_Click",this.cmdNewRecord_Click);
this.bind("cmdAdd_Click",this.cmdAdd_Click);
this.bind("cmdDelete_Click",this.cmdDelete_Click);
this.bind("chkResults_CheckStateChanged",this.chkResults_CheckStateChanged);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmImmunization";
            }

            public loaded() {

            }

        

        public frmImmunization_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmImmunization",action:"frmImmunization_Close"});
                e.preventDefault();
            }
            
        }
        public optAll_CheckedChanged(sender: frmImmunization, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public opt182_CheckedChanged(sender: frmImmunization, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public opt181_CheckedChanged(sender: frmImmunization, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public opt183_CheckedChanged(sender: frmImmunization, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public optA_CheckedChanged(sender: frmImmunization, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public optC_CheckedChanged(sender: frmImmunization, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public optB_CheckedChanged(sender: frmImmunization, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public optD_CheckedChanged(sender: frmImmunization, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboAssignmentCode_SelectionChangeCommitted(sender: frmImmunization, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboUnit_SelectionChangeCommitted(sender: frmImmunization, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboClose_Click(sender: frmImmunization, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtNameSearch_TextChanged(sender: frmImmunization, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public chkArchiveOnly_CheckStateChanged(sender: frmImmunization, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
            public loadSpread(name: string) {
                var uniqueId = this.model.UniqueID;
                require(["spread"], (spread) => {
                    spread(name, uniqueId);
                });
            }
        public cmdClear_Click(sender: frmImmunization, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdAddMuliple_Click(sender: frmImmunization, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdQuery_Click(sender: frmImmunization, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdPrintReport_Click(sender: frmImmunization, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public chkImmuneDate_CheckStateChanged(sender: frmImmunization, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdNewRecord_Click(sender: frmImmunization, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdAdd_Click(sender: frmImmunization, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdDelete_Click(sender: frmImmunization, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public chkResults_CheckStateChanged(sender: frmImmunization, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

