/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmPTSTrain", [ "files/text!views/PTSProject.frmPTSTrain.html", "files/css!views/PTSProject.frmPTSTrain.css"],
    (htmlTemplate) => {
    return class frmPTSTrain extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("calTrainDate_MouseUp",this.calTrainDate_MouseUp);
this.bind("cboUnitList_SelectionChangeCommitted",this.cboUnitList_SelectionChangeCommitted);
this.bind("cmdClear_Click",this.cmdClear_Click);
this.bind("cmdAdd_Click",this.cmdAdd_Click);
this.bind("cmdRemove_Click",this.cmdRemove_Click);
this.bind("lstSpecific_Click",this.lstSpecific_Click);
this.bind("cboHours_SelectionChangeCommitted",this.cboHours_SelectionChangeCommitted);
this.bind("cboHours_TextChanged",this.cboHours_TextChanged);
this.bind("cmdSave_Click",this.cmdSave_Click);
this.bind("cmdClose_Click",this.cmdClose_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmPTSTrain";
            }

            public loaded() {
			
            }

        

        public frmPTSTrain_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmPTSTrain",action:"frmPTSTrain_Close"});
                e.preventDefault();
            }
            
        }
        public calTrainDate_MouseUp(sender: frmPTSTrain, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboUnitList_SelectionChangeCommitted(sender: frmPTSTrain, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClear_Click(sender: frmPTSTrain, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdAdd_Click(sender: frmPTSTrain, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public cmdRemove_Click(sender: frmPTSTrain, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public lstSpecific_Click(sender: frmPTSTrain, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboHours_SelectionChangeCommitted(sender: frmPTSTrain, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboHours_TextChanged(sender: frmPTSTrain, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdSave_Click(sender: frmPTSTrain, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClose_Click(sender: frmPTSTrain, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

