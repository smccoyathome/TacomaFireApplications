/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmExtraDaysOff", [ "files/text!views/PTSProject.frmExtraDaysOff.html", "files/css!views/PTSProject.frmExtraDaysOff.css"],
    (htmlTemplate) => {
    return class frmExtraDaysOff extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("cmdPrint_Click",this.cmdPrint_Click);
this.bind("cmdClose_Click",this.cmdClose_Click);
this.bind("cboYear_SelectionChangeCommitted",this.cboYear_SelectionChangeCommitted);
this.bind("cboMonth_SelectionChangeCommitted",this.cboMonth_SelectionChangeCommitted);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmExtraDaysOff";
            }

            public loaded() {

            }

        

        public frmExtraDaysOff_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmExtraDaysOff",action:"frmExtraDaysOff_Close"});
                e.preventDefault();
            }
            
        }
        public cmdPrint_Click(sender: frmExtraDaysOff, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClose_Click(sender: frmExtraDaysOff, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboYear_SelectionChangeCommitted(sender: frmExtraDaysOff, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboMonth_SelectionChangeCommitted(sender: frmExtraDaysOff, action: string, e: any) {
            
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

