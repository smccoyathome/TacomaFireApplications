/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmIndTrainReport", [ "files/text!views/PTSProject.frmIndTrainReport.html", "files/css!views/PTSProject.frmIndTrainReport.css"],
    (htmlTemplate) => {
    return class frmIndTrainReport extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("chkInactive_CheckStateChanged",this.chkInactive_CheckStateChanged);
this.bind("cboEmployee_SelectionChangeCommitted",this.cboEmployee_SelectionChangeCommitted);
this.bind("cmdByDate_Click",this.cmdByDate_Click);
this.bind("cmdReportLevel_Click",this.cmdReportLevel_Click);
this.bind("lstSpecific_Click",this.lstSpecific_Click);
this.bind("dtStart_Click",this.dtStart_Click);
this.bind("dtStart_ValueChanged",this.dtStart_ValueChanged);
this.bind("dtEnd_Click",this.dtEnd_Click);
this.bind("dtEnd_ValueChanged",this.dtEnd_ValueChanged);
this.bind("cmdClear_Click",this.cmdClear_Click);
this.bind("cmdPrint_Click",this.cmdPrint_Click);
this.bind("cmdExit_Click",this.cmdExit_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmIndTrainReport";
            }

            public loaded() {

            }

        

        public frmIndTrainReport_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmIndTrainReport",action:"frmIndTrainReport_Close"});
                e.preventDefault();
            }
            
        }
        public chkInactive_CheckStateChanged(sender: frmIndTrainReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboEmployee_SelectionChangeCommitted(sender: frmIndTrainReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdByDate_Click(sender: frmIndTrainReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdReportLevel_Click(sender: frmIndTrainReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public lstSpecific_Click(sender: frmIndTrainReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public dtStart_Click(sender: frmIndTrainReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public dtStart_ValueChanged(sender: frmIndTrainReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public dtEnd_Click(sender: frmIndTrainReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public dtEnd_ValueChanged(sender: frmIndTrainReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClear_Click(sender: frmIndTrainReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdPrint_Click(sender: frmIndTrainReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdExit_Click(sender: frmIndTrainReport, action: string, e: any) {
            
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

