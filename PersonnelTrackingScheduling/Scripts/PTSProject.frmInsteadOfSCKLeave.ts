/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmInsteadOfSCKLeave", [ "files/text!views/PTSProject.frmInsteadOfSCKLeave.html", "files/css!views/PTSProject.frmInsteadOfSCKLeave.css"],
    (htmlTemplate) => {
    return class frmInsteadOfSCKLeave extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("dtStart_Click",this.dtStart_Click);
this.bind("cmdClose_Click",this.cmdClose_Click);
this.bind("dtEnd_Click",this.dtEnd_Click);
this.bind("cmdPrint_Click",this.cmdPrint_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmInsteadOfSCKLeave";
            }

            public loaded() {

            }

        

        public frmInsteadOfSCKLeave_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmInsteadOfSCKLeave",action:"frmInsteadOfSCKLeave_Close"});
                e.preventDefault();
            }
            
        }
        public dtStart_Click(sender: frmInsteadOfSCKLeave, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClose_Click(sender: frmInsteadOfSCKLeave, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public dtEnd_Click(sender: frmInsteadOfSCKLeave, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdPrint_Click(sender: frmInsteadOfSCKLeave, action: string, e: any) {
            
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

