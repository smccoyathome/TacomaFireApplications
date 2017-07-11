/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmPublicRoster", [ "files/text!views/PTSProject.frmPublicRoster.html", "files/css!views/PTSProject.frmPublicRoster.css"],
    (htmlTemplate) => {
    return class frmPublicRoster extends Mobilize.WebMap.Kendo.Ui.KendoView {
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
                return "frmPublicRoster";
            }

            public loaded() {

            }

        

        public frmPublicRoster_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmPublicRoster",action:"frmPublicRoster_Close"});
                e.preventDefault();
            }
            
        }
        public cmdPrint_Click(sender: frmPublicRoster, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClose_Click(sender: frmPublicRoster, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboName_SelectionChangeCommitted(sender: frmPublicRoster, action: string, e: any) {
            
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

