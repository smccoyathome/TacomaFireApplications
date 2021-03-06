/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmPPEInspQuery", [ "files/text!views/PTSProject.frmPPEInspQuery.html", "files/css!views/PTSProject.frmPPEInspQuery.css"],
    (htmlTemplate) => {
    return class frmPPEInspQuery extends Mobilize.WebMap.Kendo.Ui.KendoView {
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
this.bind("optA_CheckedChanged",this.optA_CheckedChanged);
this.bind("optC_CheckedChanged",this.optC_CheckedChanged);
this.bind("optB_CheckedChanged",this.optB_CheckedChanged);
this.bind("optD_CheckedChanged",this.optD_CheckedChanged);
this.bind("cboType_SelectionChangeCommitted",this.cboType_SelectionChangeCommitted);
this.bind("cmdClose_Click",this.cmdClose_Click);
this.bind("cboBrand_SelectionChangeCommitted",this.cboBrand_SelectionChangeCommitted);
this.bind("cmdClear_Click",this.cmdClear_Click);
this.bind("OptRetired_CheckedChanged",this.OptRetired_CheckedChanged);
this.bind("OptIssued_CheckedChanged",this.OptIssued_CheckedChanged);
this.bind("OptMisc_CheckedChanged",this.OptMisc_CheckedChanged);
this.bind("OptMonth_CheckedChanged",this.OptMonth_CheckedChanged);
this.bind("cmdPrint_Click",this.cmdPrint_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmPPEInspQuery";
            }

            public loaded() {

            }

        

        public frmPPEInspQuery_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmPPEInspQuery",action:"frmPPEInspQuery_Close"});
                e.preventDefault();
            }
            
        }
        public optAll_CheckedChanged(sender: frmPPEInspQuery, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public opt182_CheckedChanged(sender: frmPPEInspQuery, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public opt181_CheckedChanged(sender: frmPPEInspQuery, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public opt183_CheckedChanged(sender: frmPPEInspQuery, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public optA_CheckedChanged(sender: frmPPEInspQuery, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public optC_CheckedChanged(sender: frmPPEInspQuery, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public optB_CheckedChanged(sender: frmPPEInspQuery, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public optD_CheckedChanged(sender: frmPPEInspQuery, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboType_SelectionChangeCommitted(sender: frmPPEInspQuery, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClose_Click(sender: frmPPEInspQuery, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboBrand_SelectionChangeCommitted(sender: frmPPEInspQuery, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClear_Click(sender: frmPPEInspQuery, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public OptRetired_CheckedChanged(sender: frmPPEInspQuery, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public OptIssued_CheckedChanged(sender: frmPPEInspQuery, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public OptMisc_CheckedChanged(sender: frmPPEInspQuery, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public OptMonth_CheckedChanged(sender: frmPPEInspQuery, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public cmdPrint_Click(sender: frmPPEInspQuery, action: string, e: any) {
            
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

