/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmParamedicLeave", [ "files/text!views/PTSProject.frmParamedicLeave.html", "files/css!views/PTSProject.frmParamedicLeave.css"],
    (htmlTemplate) => {
    return class frmParamedicLeave extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("cboYear_SelectionChangeCommitted",this.cboYear_SelectionChangeCommitted);
this.bind("cboMonth_SelectionChangeCommitted",this.cboMonth_SelectionChangeCommitted);
this.bind("cmdPrint_Click",this.cmdPrint_Click);
this.bind("cmdClose_Click",this.cmdClose_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmParamedicLeave";
            }

            public loaded() {

            }

        

        public frmParamedicLeave_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmParamedicLeave",action:"frmParamedicLeave_Close"});
                e.preventDefault();
            }
            
        }
        public cboYear_SelectionChangeCommitted(sender: frmParamedicLeave, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboMonth_SelectionChangeCommitted(sender: frmParamedicLeave, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdPrint_Click(sender: frmParamedicLeave, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClose_Click(sender: frmParamedicLeave, action: string, e: any) {
            
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

