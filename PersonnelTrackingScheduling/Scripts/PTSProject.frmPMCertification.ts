/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmPMCertification", [ "files/text!views/PTSProject.frmPMCertification.html", "files/css!views/PTSProject.frmPMCertification.css"],
    (htmlTemplate) => {
    return class frmPMCertification extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("optFGrp_CheckedChanged",this.optFGrp_CheckedChanged);
this.bind("cmdExit_Click",this.cmdExit_Click);
this.bind("txtNameSearch_TextChanged",this.txtNameSearch_TextChanged);
this.bind("cboYear_SelectionChangeCommitted",this.cboYear_SelectionChangeCommitted);
this.bind("cmdClear_Click",this.cmdClear_Click);
this.bind("txtExpireDate_TextChanged",this.txtExpireDate_TextChanged);
this.bind("cmdDone_Click",this.cmdDone_Click);
this.bind("chkMedicFlag_CheckStateChanged",this.chkMedicFlag_CheckStateChanged);
this.bind("optGroup_CheckedChanged",this.optGroup_CheckedChanged);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmPMCertification";
            }

            public loaded() {

            }

        

        public frmPMCertification_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmPMCertification",action:"frmPMCertification_Close"});
                e.preventDefault();
            }
            
        }
        public optFGrp_CheckedChanged(sender: frmPMCertification, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public cmdExit_Click(sender: frmPMCertification, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtNameSearch_TextChanged(sender: frmPMCertification, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboYear_SelectionChangeCommitted(sender: frmPMCertification, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClear_Click(sender: frmPMCertification, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
            public loadSpread(name: string) {
                var uniqueId = this.model.UniqueID;
                require(["spread"], (spread) => {
                    spread(name, uniqueId);
                });
            }
        public txtExpireDate_TextChanged(sender: frmPMCertification, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdDone_Click(sender: frmPMCertification, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public chkMedicFlag_CheckStateChanged(sender: frmPMCertification, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public optGroup_CheckedChanged(sender: frmPMCertification, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }

    }
   
});

