/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmTransfReqAssign", [ "files/text!views/PTSProject.frmTransfReqAssign.html", "files/css!views/PTSProject.frmTransfReqAssign.css"],
    (htmlTemplate) => {
    return class frmTransfReqAssign extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("cmdPrint_Click",this.cmdPrint_Click);
this.bind("cmdClose_Click",this.cmdClose_Click);
this.bind("cboName_SelectionChangeCommitted",this.cboName_SelectionChangeCommitted);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmTransfReqAssign";
            }

            public loaded() {

            }

        

        public frmTransfReqAssign_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmTransfReqAssign",action:"frmTransfReqAssign_Close"});
                e.preventDefault();
            }
            
        }
        public cmdPrint_Click(sender: frmTransfReqAssign, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClose_Click(sender: frmTransfReqAssign, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboName_SelectionChangeCommitted(sender: frmTransfReqAssign, action: string, e: any) {
            
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

