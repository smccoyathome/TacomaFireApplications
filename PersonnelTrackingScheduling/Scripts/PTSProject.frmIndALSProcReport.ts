/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmIndALSProcReport", [ "files/text!views/PTSProject.frmIndALSProcReport.html", "files/css!views/PTSProject.frmIndALSProcReport.css"],
    (htmlTemplate) => {
    return class frmIndALSProcReport extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("cmdPrint_Click",this.cmdPrint_Click);
this.bind("cboEmployee_SelectionChangeCommitted",this.cboEmployee_SelectionChangeCommitted);
this.bind("dtStart_Click",this.dtStart_Click);
this.bind("dtStart_ValueChanged",this.dtStart_ValueChanged);
this.bind("dtEnd_Click",this.dtEnd_Click);
this.bind("dtEnd_ValueChanged",this.dtEnd_ValueChanged);
this.bind("cmdExit_Click",this.cmdExit_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmIndALSProcReport";
            }

            public loaded() {

            }

        

        public frmIndALSProcReport_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmIndALSProcReport",action:"frmIndALSProcReport_Close"});
                e.preventDefault();
            }
            
        }
        public cmdPrint_Click(sender: frmIndALSProcReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboEmployee_SelectionChangeCommitted(sender: frmIndALSProcReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public dtStart_Click(sender: frmIndALSProcReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public dtStart_ValueChanged(sender: frmIndALSProcReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public dtEnd_Click(sender: frmIndALSProcReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public dtEnd_ValueChanged(sender: frmIndALSProcReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdExit_Click(sender: frmIndALSProcReport, action: string, e: any) {
            
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

