/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmAddNew", [ "files/text!views/PTSProject.frmAddNew.html", "files/css!views/PTSProject.frmAddNew.css","usercontrols/UpgradeHelpers_Gui_ShapeHelper"],
    (htmlTemplate) => {
    return class frmAddNew extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("txtSAPEmpID_Leave",this.txtSAPEmpID_Leave);
this.bind("cmdSwitch_Click",this.cmdSwitch_Click);
this.bind("txtMName_Leave",this.txtMName_Leave);
this.bind("cboJobCode_SelectionChangeCommitted",this.cboJobCode_SelectionChangeCommitted);
this.bind("txtSex_TextChanged",this.txtSex_TextChanged);
this.bind("cmdAdd_Click",this.cmdAdd_Click);
this.bind("cmdAssign_Click",this.cmdAssign_Click);
this.bind("cmdClear_Click",this.cmdClear_Click);
this.bind("cmdClose_Click",this.cmdClose_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmAddNew";
            }

            public loaded() {
			
            }

        

        public frmAddNew_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmAddNew",action:"frmAddNew_Close"});
                e.preventDefault();
            }
            
        }
        public txtSAPEmpID_Leave(sender: frmAddNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdSwitch_Click(sender: frmAddNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtMName_Leave(sender: frmAddNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboJobCode_SelectionChangeCommitted(sender: frmAddNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtSex_TextChanged(sender: frmAddNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdAdd_Click(sender: frmAddNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdAssign_Click(sender: frmAddNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClear_Click(sender: frmAddNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClose_Click(sender: frmAddNew, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

