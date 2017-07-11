/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmRankedOperationStaff", [ "files/text!views/PTSProject.frmRankedOperationStaff.html", "files/css!views/PTSProject.frmRankedOperationStaff.css"],
    (htmlTemplate) => {
    return class frmRankedOperationStaff extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("cmdExit_Click",this.cmdExit_Click);
this.bind("cboGroup_SelectionChangeCommitted",this.cboGroup_SelectionChangeCommitted);
this.bind("chkSelectAll_CheckStateChanged",this.chkSelectAll_CheckStateChanged);
this.bind("cmdPrint_Click",this.cmdPrint_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmRankedOperationStaff";
            }

            public loaded() {

            }

        

        public frmRankedOperationStaff_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmRankedOperationStaff",action:"frmRankedOperationStaff_Close"});
                e.preventDefault();
            }
            
        }
        public cmdExit_Click(sender: frmRankedOperationStaff, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboGroup_SelectionChangeCommitted(sender: frmRankedOperationStaff, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public chkSelectAll_CheckStateChanged(sender: frmRankedOperationStaff, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdPrint_Click(sender: frmRankedOperationStaff, action: string, e: any) {
            
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

