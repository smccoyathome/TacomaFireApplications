/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.dlgSendRover", [ "files/text!views/PTSProject.dlgSendRover.html", "files/css!views/PTSProject.dlgSendRover.css"],
    (htmlTemplate) => {
    return class dlgSendRover extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("chkAM_CheckStateChanged",this.chkAM_CheckStateChanged);
this.bind("chkRover_CheckStateChanged",this.chkRover_CheckStateChanged);
this.bind("chkPM_CheckStateChanged",this.chkPM_CheckStateChanged);
this.bind("chkDebit_CheckStateChanged",this.chkDebit_CheckStateChanged);
this.bind("chkBoth_CheckStateChanged",this.chkBoth_CheckStateChanged);
this.bind("cmdOK_Click",this.cmdOK_Click);
this.bind("cmdCancel_Click",this.cmdCancel_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "dlgSendRover";
            }

            public loaded() {
			
            }

        

        public dlgSendRover_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"dlgSendRover",action:"dlgSendRover_Close"});
                e.preventDefault();
            }
            
        }
        public chkAM_CheckStateChanged(sender: dlgSendRover, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public chkRover_CheckStateChanged(sender: dlgSendRover, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public chkPM_CheckStateChanged(sender: dlgSendRover, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public chkDebit_CheckStateChanged(sender: dlgSendRover, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public chkBoth_CheckStateChanged(sender: dlgSendRover, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdOK_Click(sender: dlgSendRover, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdCancel_Click(sender: dlgSendRover, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

