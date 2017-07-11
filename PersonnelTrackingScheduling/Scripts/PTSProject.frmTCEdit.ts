/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmTCEdit", [ "files/text!views/PTSProject.frmTCEdit.html", "files/css!views/PTSProject.frmTCEdit.css"],
    (htmlTemplate) => {
    return class frmTCEdit extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("cmdNotes_Click",this.cmdNotes_Click);
this.bind("cmdDeleteNotes_Click",this.cmdDeleteNotes_Click);
this.bind("cboKOT_SelectionChangeCommitted",this.cboKOT_SelectionChangeCommitted);
this.bind("cboAAType_SelectionChangeCommitted",this.cboAAType_SelectionChangeCommitted);
this.bind("cboLeave_SelectionChangeCommitted",this.cboLeave_SelectionChangeCommitted);
this.bind("cboLeaveAA_SelectionChangeCommitted",this.cboLeaveAA_SelectionChangeCommitted);
this.bind("cboJobCode_SelectionChangeCommitted",this.cboJobCode_SelectionChangeCommitted);
this.bind("cboStep_SelectionChangeCommitted",this.cboStep_SelectionChangeCommitted);
this.bind("txtHours_TextChanged",this.txtHours_TextChanged);
this.bind("cmdClose_Click",this.cmdClose_Click);
this.bind("cmdCancel_Click",this.cmdCancel_Click);
this.bind("cmdSchedule_Click",this.cmdSchedule_Click);
this.bind("cmdTrade_Click",this.cmdTrade_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmTCEdit";
            }

            public loaded() {
			
            }

        

        public frmTCEdit_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmTCEdit",action:"frmTCEdit_Close"});
                e.preventDefault();
            }
            
        }
        public cmdNotes_Click(sender: frmTCEdit, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdDeleteNotes_Click(sender: frmTCEdit, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboKOT_SelectionChangeCommitted(sender: frmTCEdit, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public cboAAType_SelectionChangeCommitted(sender: frmTCEdit, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public cboLeave_SelectionChangeCommitted(sender: frmTCEdit, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public cboLeaveAA_SelectionChangeCommitted(sender: frmTCEdit, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public cboJobCode_SelectionChangeCommitted(sender: frmTCEdit, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public cboStep_SelectionChangeCommitted(sender: frmTCEdit, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public txtHours_TextChanged(sender: frmTCEdit, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public cmdClose_Click(sender: frmTCEdit, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdCancel_Click(sender: frmTCEdit, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdSchedule_Click(sender: frmTCEdit, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdTrade_Click(sender: frmTCEdit, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

