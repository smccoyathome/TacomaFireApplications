/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.dlgTransfer", [ "files/text!views/PTSProject.dlgTransfer.html", "files/css!views/PTSProject.dlgTransfer.css"],
    (htmlTemplate) => {
    return class dlgTransfer extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("chkTemp_CheckStateChanged",this.chkTemp_CheckStateChanged);
this.bind("cmdDone_Click",this.cmdDone_Click);
this.bind("cmdCancel_Click",this.cmdCancel_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "dlgTransfer";
            }

            public loaded() {
			
            }

        

        public dlgTransfer_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"dlgTransfer",action:"dlgTransfer_Close"});
                e.preventDefault();
            }
            
        }
        public chkTemp_CheckStateChanged(sender: dlgTransfer, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdDone_Click(sender: dlgTransfer, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdCancel_Click(sender: dlgTransfer, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

