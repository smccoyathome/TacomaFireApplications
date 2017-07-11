/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmGlobeData", [ "files/text!views/PTSProject.frmGlobeData.html", "files/css!views/PTSProject.frmGlobeData.css"],
    (htmlTemplate) => {
    return class frmGlobeData extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("cboType_SelectionChangeCommitted",this.cboType_SelectionChangeCommitted);
this.bind("cboChstWaist_SelectionChangeCommitted",this.cboChstWaist_SelectionChangeCommitted);
this.bind("cboColor_SelectionChangeCommitted",this.cboColor_SelectionChangeCommitted);
this.bind("cmdClose_Click",this.cmdClose_Click);
this.bind("cboStation_SelectionChangeCommitted",this.cboStation_SelectionChangeCommitted);
this.bind("cboLength_SelectionChangeCommitted",this.cboLength_SelectionChangeCommitted);
this.bind("cboOrder_SelectionChangeCommitted",this.cboOrder_SelectionChangeCommitted);
this.bind("cmdClear_Click",this.cmdClear_Click);
this.bind("txtNameSearch_TextChanged",this.txtNameSearch_TextChanged);
this.bind("cboSleeve_SelectionChangeCommitted",this.cboSleeve_SelectionChangeCommitted);
this.bind("cboStyle_SelectionChangeCommitted",this.cboStyle_SelectionChangeCommitted);
this.bind("cmdPrint_Click",this.cmdPrint_Click);
this.bind("cboManufDate_SelectionChangeCommitted",this.cboManufDate_SelectionChangeCommitted);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmGlobeData";
            }

            public loaded() {

            }

        

        public frmGlobeData_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmGlobeData",action:"frmGlobeData_Close"});
                e.preventDefault();
            }
            
        }
        public cboType_SelectionChangeCommitted(sender: frmGlobeData, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboChstWaist_SelectionChangeCommitted(sender: frmGlobeData, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboColor_SelectionChangeCommitted(sender: frmGlobeData, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClose_Click(sender: frmGlobeData, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboStation_SelectionChangeCommitted(sender: frmGlobeData, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboLength_SelectionChangeCommitted(sender: frmGlobeData, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboOrder_SelectionChangeCommitted(sender: frmGlobeData, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClear_Click(sender: frmGlobeData, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtNameSearch_TextChanged(sender: frmGlobeData, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboSleeve_SelectionChangeCommitted(sender: frmGlobeData, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboStyle_SelectionChangeCommitted(sender: frmGlobeData, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdPrint_Click(sender: frmGlobeData, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboManufDate_SelectionChangeCommitted(sender: frmGlobeData, action: string, e: any) {
            
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

