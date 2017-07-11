/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmPPEInventory", [ "files/text!views/PTSProject.frmPPEInventory.html", "files/css!views/PTSProject.frmPPEInventory.css"],
    (htmlTemplate) => {
    return class frmPPEInventory extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("cmdExit_Click",this.cmdExit_Click);
this.bind("cboLocation_SelectionChangeCommitted",this.cboLocation_SelectionChangeCommitted);
this.bind("cboBrand_SelectionChangeCommitted",this.cboBrand_SelectionChangeCommitted);
this.bind("cmdClear_Click",this.cmdClear_Click);
this.bind("cboType_SelectionChangeCommitted",this.cboType_SelectionChangeCommitted);
this.bind("cboColorSize_SelectionChangeCommitted",this.cboColorSize_SelectionChangeCommitted);
this.bind("cmdRefresh_Click",this.cmdRefresh_Click);
this.bind("chkInactive_CheckStateChanged",this.chkInactive_CheckStateChanged);
this.bind("cmdPrint_Click",this.cmdPrint_Click);
this.bind("cmdNewItem_Click",this.cmdNewItem_Click);
this.bind("chkManufDate_CheckStateChanged",this.chkManufDate_CheckStateChanged);
this.bind("cboStation_SelectionChangeCommitted",this.cboStation_SelectionChangeCommitted);
this.bind("txtTrackingNumber_TextChanged",this.txtTrackingNumber_TextChanged);
this.bind("dteManufDate_Click",this.dteManufDate_Click);
this.bind("cmdEditItem_Click",this.cmdEditItem_Click);
this.bind("cmdFind_Click",this.cmdFind_Click);
this.bind("cmdRetireItem_Click",this.cmdRetireItem_Click);
this.bind("cmdReactivate_Click",this.cmdReactivate_Click);
this.bind("cboItemType_SelectionChangeCommitted",this.cboItemType_SelectionChangeCommitted);
this.bind("cboItemColorSize_SelectionChangeCommitted",this.cboItemColorSize_SelectionChangeCommitted);
this.bind("cboItemBrand_SelectionChangeCommitted",this.cboItemBrand_SelectionChangeCommitted);
this.bind("cmdRepair_Click",this.cmdRepair_Click);
this.bind("cboReason_SelectionChangeCommitted",this.cboReason_SelectionChangeCommitted);
this.bind("dteRetired_Click",this.dteRetired_Click);
this.bind("cmdCleaning_Click",this.cmdCleaning_Click);
this.bind("cmdLastInsp_Click",this.cmdLastInsp_Click);
this.bind("cmdAddNew_Click",this.cmdAddNew_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmPPEInventory";
            }

            public loaded() {

            }

        

        public frmPPEInventory_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmPPEInventory",action:"frmPPEInventory_Close"});
                e.preventDefault();
            }
            
        }
        public cmdExit_Click(sender: frmPPEInventory, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboLocation_SelectionChangeCommitted(sender: frmPPEInventory, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboBrand_SelectionChangeCommitted(sender: frmPPEInventory, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClear_Click(sender: frmPPEInventory, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboType_SelectionChangeCommitted(sender: frmPPEInventory, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboColorSize_SelectionChangeCommitted(sender: frmPPEInventory, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdRefresh_Click(sender: frmPPEInventory, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public chkInactive_CheckStateChanged(sender: frmPPEInventory, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdPrint_Click(sender: frmPPEInventory, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
            public loadSpread(name: string) {
                var uniqueId = this.model.UniqueID;
                require(["spread"], (spread) => {
                    spread(name, uniqueId);
                });
            }
        public cmdNewItem_Click(sender: frmPPEInventory, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public chkManufDate_CheckStateChanged(sender: frmPPEInventory, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboStation_SelectionChangeCommitted(sender: frmPPEInventory, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtTrackingNumber_TextChanged(sender: frmPPEInventory, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public dteManufDate_Click(sender: frmPPEInventory, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdEditItem_Click(sender: frmPPEInventory, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdFind_Click(sender: frmPPEInventory, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdRetireItem_Click(sender: frmPPEInventory, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdReactivate_Click(sender: frmPPEInventory, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboItemType_SelectionChangeCommitted(sender: frmPPEInventory, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboItemColorSize_SelectionChangeCommitted(sender: frmPPEInventory, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboItemBrand_SelectionChangeCommitted(sender: frmPPEInventory, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdRepair_Click(sender: frmPPEInventory, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboReason_SelectionChangeCommitted(sender: frmPPEInventory, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public dteRetired_Click(sender: frmPPEInventory, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdCleaning_Click(sender: frmPPEInventory, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdLastInsp_Click(sender: frmPPEInventory, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdAddNew_Click(sender: frmPPEInventory, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

