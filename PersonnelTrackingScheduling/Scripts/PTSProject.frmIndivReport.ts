/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmIndivReport", [ "files/text!views/PTSProject.frmIndivReport.html", "files/css!views/PTSProject.frmIndivReport.css"],
    (htmlTemplate) => {
    return class frmIndivReport extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("cmdPrint_Click",this.cmdPrint_Click);
this.bind("cmdClose_Click",this.cmdClose_Click);
this.bind("chkInactive_CheckStateChanged",this.chkInactive_CheckStateChanged);
this.bind("cboYear_SelectionChangeCommitted",this.cboYear_SelectionChangeCommitted);
this.bind("cboNameList_SelectionChangeCommitted",this.cboNameList_SelectionChangeCommitted);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmIndivReport";
            }

            public loaded() {

            }

        

        public frmIndivReport_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmIndivReport",action:"frmIndivReport_Close"});
                e.preventDefault();
            }
            
        }
        public cmdPrint_Click(sender: frmIndivReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClose_Click(sender: frmIndivReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public chkInactive_CheckStateChanged(sender: frmIndivReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboYear_SelectionChangeCommitted(sender: frmIndivReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboNameList_SelectionChangeCommitted(sender: frmIndivReport, action: string, e: any) {
            
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

