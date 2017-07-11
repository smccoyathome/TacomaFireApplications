/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmNotify", [ "files/text!views/PTSProject.frmNotify.html", "files/css!views/PTSProject.frmNotify.css"],
    (htmlTemplate) => {
    return class frmNotify extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("cboNotify_SelectionChangeCommitted",this.cboNotify_SelectionChangeCommitted);
this.bind("cmdClosePeriod_Click",this.cmdClosePeriod_Click);
this.bind("cmdPrint_Click",this.cmdPrint_Click);
this.bind("cmdPayDetail_Click",this.cmdPayDetail_Click);
this.bind("cmdClose_Click",this.cmdClose_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmNotify";
            }

            public loaded() {

            }

        

        public frmNotify_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmNotify",action:"frmNotify_Close"});
                e.preventDefault();
            }
            
        }
        public cboNotify_SelectionChangeCommitted(sender: frmNotify, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
            public loadSpread(name: string) {
                var uniqueId = this.model.UniqueID;
                require(["spread"], (spread) => {
                    spread(name, uniqueId);
                });
            }
        public cmdClosePeriod_Click(sender: frmNotify, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdPrint_Click(sender: frmNotify, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdPayDetail_Click(sender: frmNotify, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClose_Click(sender: frmNotify, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

