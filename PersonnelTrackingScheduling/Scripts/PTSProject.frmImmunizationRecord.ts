/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmImmunizationRecord", [ "files/text!views/PTSProject.frmImmunizationRecord.html", "files/css!views/PTSProject.frmImmunizationRecord.css"],
    (htmlTemplate) => {
    return class frmImmunizationRecord extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("cmdPrint_Click",this.cmdPrint_Click);
this.bind("cmbClose_Click",this.cmbClose_Click);
this.bind("cboEmpList_SelectionChangeCommitted",this.cboEmpList_SelectionChangeCommitted);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmImmunizationRecord";
            }

            public loaded() {

            }

        

        public frmImmunizationRecord_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmImmunizationRecord",action:"frmImmunizationRecord_Close"});
                e.preventDefault();
            }
            
        }
        public cmdPrint_Click(sender: frmImmunizationRecord, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmbClose_Click(sender: frmImmunizationRecord, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboEmpList_SelectionChangeCommitted(sender: frmImmunizationRecord, action: string, e: any) {
            
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

