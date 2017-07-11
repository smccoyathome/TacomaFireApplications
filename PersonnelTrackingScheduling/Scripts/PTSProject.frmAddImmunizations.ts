/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmAddImmunizations", [ "files/text!views/PTSProject.frmAddImmunizations.html", "files/css!views/PTSProject.frmAddImmunizations.css"],
    (htmlTemplate) => {
    return class frmAddImmunizations extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("optAll_CheckedChanged",this.optAll_CheckedChanged);
this.bind("opt182_CheckedChanged",this.opt182_CheckedChanged);
this.bind("opt181_CheckedChanged",this.opt181_CheckedChanged);
this.bind("opt183_CheckedChanged",this.opt183_CheckedChanged);
this.bind("cboUnit_SelectionChangeCommitted",this.cboUnit_SelectionChangeCommitted);
this.bind("cmdClose_Click",this.cmdClose_Click);
this.bind("optA_CheckedChanged",this.optA_CheckedChanged);
this.bind("optC_CheckedChanged",this.optC_CheckedChanged);
this.bind("optB_CheckedChanged",this.optB_CheckedChanged);
this.bind("optD_CheckedChanged",this.optD_CheckedChanged);
this.bind("cmdClear_Click",this.cmdClear_Click);
this.bind("cboAssignmentCode_SelectionChangeCommitted",this.cboAssignmentCode_SelectionChangeCommitted);
this.bind("cmdAdd_Click",this.cmdAdd_Click);
this.bind("cmdRemove_Click",this.cmdRemove_Click);
this.bind("chkImmuneDate_CheckStateChanged",this.chkImmuneDate_CheckStateChanged);
this.bind("cmdNewRecord_Click",this.cmdNewRecord_Click);
this.bind("cboType_SelectionChangeCommitted",this.cboType_SelectionChangeCommitted);
this.bind("cmdAddRecord_Click",this.cmdAddRecord_Click);
this.bind("chkResults_CheckStateChanged",this.chkResults_CheckStateChanged);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmAddImmunizations";
            }

            public loaded() {
			
            }

        

        public frmAddImmunizations_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmAddImmunizations",action:"frmAddImmunizations_Close"});
                e.preventDefault();
            }
            
        }
        public optAll_CheckedChanged(sender: frmAddImmunizations, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public opt182_CheckedChanged(sender: frmAddImmunizations, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public opt181_CheckedChanged(sender: frmAddImmunizations, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public opt183_CheckedChanged(sender: frmAddImmunizations, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboUnit_SelectionChangeCommitted(sender: frmAddImmunizations, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClose_Click(sender: frmAddImmunizations, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public optA_CheckedChanged(sender: frmAddImmunizations, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public optC_CheckedChanged(sender: frmAddImmunizations, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public optB_CheckedChanged(sender: frmAddImmunizations, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public optD_CheckedChanged(sender: frmAddImmunizations, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClear_Click(sender: frmAddImmunizations, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboAssignmentCode_SelectionChangeCommitted(sender: frmAddImmunizations, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdAdd_Click(sender: frmAddImmunizations, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public cmdRemove_Click(sender: frmAddImmunizations, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public chkImmuneDate_CheckStateChanged(sender: frmAddImmunizations, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdNewRecord_Click(sender: frmAddImmunizations, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboType_SelectionChangeCommitted(sender: frmAddImmunizations, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdAddRecord_Click(sender: frmAddImmunizations, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public chkResults_CheckStateChanged(sender: frmAddImmunizations, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

