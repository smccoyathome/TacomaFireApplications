/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.dlgTrade", [ "files/text!views/PTSProject.dlgTrade.html", "files/css!views/PTSProject.dlgTrade.css","usercontrols/UpgradeHelpers_Gui_ShapeHelper"],
    (htmlTemplate) => {
    return class dlgTrade extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("cboFullList_SelectionChangeCommitted",this.cboFullList_SelectionChangeCommitted);
this.bind("chkAMPM_CheckStateChanged",this.chkAMPM_CheckStateChanged);
this.bind("cmdOK_Click",this.cmdOK_Click);
this.bind("cmdCancel_Click",this.cmdCancel_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "dlgTrade";
            }

            public loaded() {
			
            }

        

        public dlgTrade_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"dlgTrade",action:"dlgTrade_Close"});
                e.preventDefault();
            }
            
        }
        public cboFullList_SelectionChangeCommitted(sender: dlgTrade, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public chkAMPM_CheckStateChanged(sender: dlgTrade, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdOK_Click(sender: dlgTrade, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdCancel_Click(sender: dlgTrade, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

