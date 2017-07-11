/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmMasterPhoneLists", [ "files/text!views/PTSProject.frmMasterPhoneLists.html", "files/css!views/PTSProject.frmMasterPhoneLists.css"],
    (htmlTemplate) => {
    return class frmMasterPhoneLists extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("cmdClose_Click",this.cmdClose_Click);
this.bind("optList_CheckedChanged",this.optList_CheckedChanged);
this.bind("cmdClearFacility_Click",this.cmdClearFacility_Click);
this.bind("cboFFacility_SelectionChangeCommitted",this.cboFFacility_SelectionChangeCommitted);
this.bind("cboFType_SelectionChangeCommitted",this.cboFType_SelectionChangeCommitted);
this.bind("cmdPrintFacility_Click",this.cmdPrintFacility_Click);
this.bind("chkCBOnly_CheckStateChanged",this.chkCBOnly_CheckStateChanged);
this.bind("cmdClearEmployee_Click",this.cmdClearEmployee_Click);
this.bind("cboEFacility_SelectionChangeCommitted",this.cboEFacility_SelectionChangeCommitted);
this.bind("cboUnit_SelectionChangeCommitted",this.cboUnit_SelectionChangeCommitted);
this.bind("cboEType_SelectionChangeCommitted",this.cboEType_SelectionChangeCommitted);
this.bind("cboAssignType_SelectionChangeCommitted",this.cboAssignType_SelectionChangeCommitted);
this.bind("cboGroup_SelectionChangeCommitted",this.cboGroup_SelectionChangeCommitted);
this.bind("cmdPrintEmployee_Click",this.cmdPrintEmployee_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmMasterPhoneLists";
            }

            public loaded() {

            }

        

        public frmMasterPhoneLists_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmMasterPhoneLists",action:"frmMasterPhoneLists_Close"});
                e.preventDefault();
            }
            
        }
        public cmdClose_Click(sender: frmMasterPhoneLists, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public optList_CheckedChanged(sender: frmMasterPhoneLists, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public cmdClearFacility_Click(sender: frmMasterPhoneLists, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboFFacility_SelectionChangeCommitted(sender: frmMasterPhoneLists, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboFType_SelectionChangeCommitted(sender: frmMasterPhoneLists, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdPrintFacility_Click(sender: frmMasterPhoneLists, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
            public loadSpread(name: string) {
                var uniqueId = this.model.UniqueID;
                require(["spread"], (spread) => {
                    spread(name, uniqueId);
                });
            }
        public chkCBOnly_CheckStateChanged(sender: frmMasterPhoneLists, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClearEmployee_Click(sender: frmMasterPhoneLists, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboEFacility_SelectionChangeCommitted(sender: frmMasterPhoneLists, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboUnit_SelectionChangeCommitted(sender: frmMasterPhoneLists, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboEType_SelectionChangeCommitted(sender: frmMasterPhoneLists, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboAssignType_SelectionChangeCommitted(sender: frmMasterPhoneLists, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboGroup_SelectionChangeCommitted(sender: frmMasterPhoneLists, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdPrintEmployee_Click(sender: frmMasterPhoneLists, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

