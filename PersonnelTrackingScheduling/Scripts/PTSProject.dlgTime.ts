/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.dlgTime", [ "files/text!views/PTSProject.dlgTime.html", "files/css!views/PTSProject.dlgTime.css","usercontrols/UpgradeHelpers_Gui_ShapeHelper"],
    (htmlTemplate) => {
    return class dlgTime extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("cboLeave_SelectionChangeCommitted",this.cboLeave_SelectionChangeCommitted);
this.bind("cboJob_SelectionChangeCommitted",this.cboJob_SelectionChangeCommitted);
this.bind("chkVacBank_CheckStateChanged",this.chkVacBank_CheckStateChanged);
this.bind("chkSCKflag_CheckStateChanged",this.chkSCKflag_CheckStateChanged);
this.bind("chkExtend_CheckStateChanged",this.chkExtend_CheckStateChanged);
this.bind("cmdOK_Click",this.cmdOK_Click);
this.bind("cmdCancel_Click",this.cmdCancel_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "dlgTime";
            }

            public loaded() {
			
            }

        

        public dlgTime_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"dlgTime",action:"dlgTime_Close"});
                e.preventDefault();
            }
            
        }
        public cboLeave_SelectionChangeCommitted(sender: dlgTime, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboJob_SelectionChangeCommitted(sender: dlgTime, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public chkVacBank_CheckStateChanged(sender: dlgTime, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public chkSCKflag_CheckStateChanged(sender: dlgTime, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public chkExtend_CheckStateChanged(sender: dlgTime, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdOK_Click(sender: dlgTime, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdCancel_Click(sender: dlgTime, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

