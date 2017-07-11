/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmIndPMRecertReport", [ "files/text!views/PTSProject.frmIndPMRecertReport.html", "files/css!views/PTSProject.frmIndPMRecertReport.css"],
    (htmlTemplate) => {
    return class frmIndPMRecertReport extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("cboEmployee_SelectionChangeCommitted",this.cboEmployee_SelectionChangeCommitted);
this.bind("cmdPrint_Click",this.cmdPrint_Click);
this.bind("dtStart_Click",this.dtStart_Click);
this.bind("dtStart_ValueChanged",this.dtStart_ValueChanged);
this.bind("dtEnd_Click",this.dtEnd_Click);
this.bind("dtEnd_ValueChanged",this.dtEnd_ValueChanged);
this.bind("cmdExit_Click",this.cmdExit_Click);
this.bind("chkDoNotChange_CheckStateChanged",this.chkDoNotChange_CheckStateChanged);
this.bind("chkOTEPOnly_CheckStateChanged",this.chkOTEPOnly_CheckStateChanged);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmIndPMRecertReport";
            }

            public loaded() {

            }

        

        public frmIndPMRecertReport_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmIndPMRecertReport",action:"frmIndPMRecertReport_Close"});
                e.preventDefault();
            }
            
        }
        public cboEmployee_SelectionChangeCommitted(sender: frmIndPMRecertReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdPrint_Click(sender: frmIndPMRecertReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public dtStart_Click(sender: frmIndPMRecertReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public dtStart_ValueChanged(sender: frmIndPMRecertReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public dtEnd_Click(sender: frmIndPMRecertReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public dtEnd_ValueChanged(sender: frmIndPMRecertReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdExit_Click(sender: frmIndPMRecertReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public chkDoNotChange_CheckStateChanged(sender: frmIndPMRecertReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public chkOTEPOnly_CheckStateChanged(sender: frmIndPMRecertReport, action: string, e: any) {
            
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

