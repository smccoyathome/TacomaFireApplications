/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmTrainAnnualOTEP", [ "files/text!views/PTSProject.frmTrainAnnualOTEP.html", "files/css!views/PTSProject.frmTrainAnnualOTEP.css"],
    (htmlTemplate) => {
    return class frmTrainAnnualOTEP extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("cmdClose_Click",this.cmdClose_Click);
this.bind("optAll_CheckedChanged",this.optAll_CheckedChanged);
this.bind("opt182_CheckedChanged",this.opt182_CheckedChanged);
this.bind("opt181_CheckedChanged",this.opt181_CheckedChanged);
this.bind("opt183_CheckedChanged",this.opt183_CheckedChanged);
this.bind("optA_CheckedChanged",this.optA_CheckedChanged);
this.bind("optC_CheckedChanged",this.optC_CheckedChanged);
this.bind("optB_CheckedChanged",this.optB_CheckedChanged);
this.bind("optD_CheckedChanged",this.optD_CheckedChanged);
this.bind("optGrp1_CheckedChanged",this.optGrp1_CheckedChanged);
this.bind("optGrp2_CheckedChanged",this.optGrp2_CheckedChanged);
this.bind("optGrp3_CheckedChanged",this.optGrp3_CheckedChanged);
this.bind("cboYear_SelectionChangeCommitted",this.cboYear_SelectionChangeCommitted);
this.bind("cmdClear_Click",this.cmdClear_Click);
this.bind("optPM_CheckedChanged",this.optPM_CheckedChanged);
this.bind("cmdPrint_Click",this.cmdPrint_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmTrainAnnualOTEP";
            }

            public loaded() {

            }

        

        public frmTrainAnnualOTEP_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmTrainAnnualOTEP",action:"frmTrainAnnualOTEP_Close"});
                e.preventDefault();
            }
            
        }
        public cmdClose_Click(sender: frmTrainAnnualOTEP, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public optAll_CheckedChanged(sender: frmTrainAnnualOTEP, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public opt182_CheckedChanged(sender: frmTrainAnnualOTEP, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public opt181_CheckedChanged(sender: frmTrainAnnualOTEP, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public opt183_CheckedChanged(sender: frmTrainAnnualOTEP, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public optA_CheckedChanged(sender: frmTrainAnnualOTEP, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public optC_CheckedChanged(sender: frmTrainAnnualOTEP, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public optB_CheckedChanged(sender: frmTrainAnnualOTEP, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public optD_CheckedChanged(sender: frmTrainAnnualOTEP, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public optGrp1_CheckedChanged(sender: frmTrainAnnualOTEP, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public optGrp2_CheckedChanged(sender: frmTrainAnnualOTEP, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public optGrp3_CheckedChanged(sender: frmTrainAnnualOTEP, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboYear_SelectionChangeCommitted(sender: frmTrainAnnualOTEP, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClear_Click(sender: frmTrainAnnualOTEP, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public optPM_CheckedChanged(sender: frmTrainAnnualOTEP, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdPrint_Click(sender: frmTrainAnnualOTEP, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
            public loadSpread(name: string) {
                var uniqueId = this.model.UniqueID;
                require(["spread"], (spread) => {
                    spread(name, uniqueId);
                });
            }

    }
   
});

