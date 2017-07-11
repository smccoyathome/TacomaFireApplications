/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("TFDIncident.dlgHIPAAMsg", [ "files/text!views/TFDIncident.dlgHIPAAMsg.html", "files/css!views/TFDIncident.dlgHIPAAMsg.css"],
    (htmlTemplate) => {
    return class dlgHIPAAMsg extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("txtReleaseName_TextChanged",this.txtReleaseName_TextChanged);
this.bind("txtReleaseAdd1_TextChanged",this.txtReleaseAdd1_TextChanged);
this.bind("txtReleaseAdd2_TextChanged",this.txtReleaseAdd2_TextChanged);
this.bind("txtReleaseReason_TextChanged",this.txtReleaseReason_TextChanged);
this.bind("cmdCancel_Click",this.cmdCancel_Click);
this.bind("cmdPrint_Click",this.cmdPrint_Click);
this.bind("cmdOut_Click",this.cmdOut_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "dlgHIPAAMsg";
            }

            public loaded() {

            }

        

        public dlgHIPAAMsg_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"dlgHIPAAMsg",action:"dlgHIPAAMsg_Close"});
                e.preventDefault();
            }
            
        }
            public loadSpread(name: string) {
                var uniqueId = this.model.UniqueID;
                require(["spread"], (spread) => {
                    spread(name, uniqueId);
                });
            }
        public txtReleaseName_TextChanged(sender: dlgHIPAAMsg, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtReleaseAdd1_TextChanged(sender: dlgHIPAAMsg, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtReleaseAdd2_TextChanged(sender: dlgHIPAAMsg, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtReleaseReason_TextChanged(sender: dlgHIPAAMsg, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdCancel_Click(sender: dlgHIPAAMsg, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdPrint_Click(sender: dlgHIPAAMsg, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdOut_Click(sender: dlgHIPAAMsg, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

