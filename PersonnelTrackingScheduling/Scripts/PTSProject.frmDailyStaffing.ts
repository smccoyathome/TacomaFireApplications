/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmDailyStaffing", [ "files/text!views/PTSProject.frmDailyStaffing.html", "files/css!views/PTSProject.frmDailyStaffing.css"],
    (htmlTemplate) => {
    return class frmDailyStaffing extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("cmdOvertime_Click",this.cmdOvertime_Click);
this.bind("cmdPrint_Click",this.cmdPrint_Click);
this.bind("cmdFilter_Click",this.cmdFilter_Click);
this.bind("cboYear_SelectionChangeCommitted",this.cboYear_SelectionChangeCommitted);
this.bind("cboMonth_SelectionChangeCommitted",this.cboMonth_SelectionChangeCommitted);
this.bind("cmdAnnualLeave_Click",this.cmdAnnualLeave_Click);
this.bind("cmdClose_Click",this.cmdClose_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmDailyStaffing";
            }

            public loaded() {

            }

        

        public frmDailyStaffing_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmDailyStaffing",action:"frmDailyStaffing_Close"});
                e.preventDefault();
            }
            
        }
        public cmdOvertime_Click(sender: frmDailyStaffing, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdPrint_Click(sender: frmDailyStaffing, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdFilter_Click(sender: frmDailyStaffing, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public cboYear_SelectionChangeCommitted(sender: frmDailyStaffing, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboMonth_SelectionChangeCommitted(sender: frmDailyStaffing, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdAnnualLeave_Click(sender: frmDailyStaffing, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClose_Click(sender: frmDailyStaffing, action: string, e: any) {
            
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

