/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmEmployeeSizes", [ "files/text!views/PTSProject.frmEmployeeSizes.html", "files/css!views/PTSProject.frmEmployeeSizes.css"],
    (htmlTemplate) => {
    return class frmEmployeeSizes extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("optBunker_CheckedChanged",this.optBunker_CheckedChanged);
this.bind("optUniform_CheckedChanged",this.optUniform_CheckedChanged);
this.bind("cmdClose_Click",this.cmdClose_Click);
this.bind("cboEmpList_SelectionChangeCommitted",this.cboEmpList_SelectionChangeCommitted);
this.bind("chkChangeDate_CheckStateChanged",this.chkChangeDate_CheckStateChanged);
this.bind("cmdEditUniformSize_Click",this.cmdEditUniformSize_Click);
this.bind("cboUniformItem_SelectionChangeCommitted",this.cboUniformItem_SelectionChangeCommitted);
this.bind("txtItemSizeDesc_TextChanged",this.txtItemSizeDesc_TextChanged);
this.bind("cmdNewRecord_Click",this.cmdNewRecord_Click);
this.bind("chkInDate_CheckStateChanged",this.chkInDate_CheckStateChanged);
this.bind("cmdEdit_Click",this.cmdEdit_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmEmployeeSizes";
            }

            public loaded() {

            }

        

        public frmEmployeeSizes_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmEmployeeSizes",action:"frmEmployeeSizes_Close"});
                e.preventDefault();
            }
            
        }
        public optBunker_CheckedChanged(sender: frmEmployeeSizes, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public optUniform_CheckedChanged(sender: frmEmployeeSizes, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClose_Click(sender: frmEmployeeSizes, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboEmpList_SelectionChangeCommitted(sender: frmEmployeeSizes, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
            public loadSpread(name: string) {
                var uniqueId = this.model.UniqueID;
                require(["spread"], (spread) => {
                    spread(name, uniqueId);
                });
            }
        public chkChangeDate_CheckStateChanged(sender: frmEmployeeSizes, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdEditUniformSize_Click(sender: frmEmployeeSizes, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboUniformItem_SelectionChangeCommitted(sender: frmEmployeeSizes, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtItemSizeDesc_TextChanged(sender: frmEmployeeSizes, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdNewRecord_Click(sender: frmEmployeeSizes, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public chkInDate_CheckStateChanged(sender: frmEmployeeSizes, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdEdit_Click(sender: frmEmployeeSizes, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

