/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmNewQClass", [ "files/text!views/PTSProject.frmNewQClass.html", "files/css!views/PTSProject.frmNewQClass.css"],
    (htmlTemplate) => {
    return class frmNewQClass extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("cboPrimary_SelectionChangeCommitted",this.cboPrimary_SelectionChangeCommitted);
this.bind("cboSecondary_SelectionChangeCommitted",this.cboSecondary_SelectionChangeCommitted);
this.bind("cboClass_SelectionChangeCommitted",this.cboClass_SelectionChangeCommitted);
this.bind("cmdQuery_Click",this.cmdQuery_Click);
this.bind("cmdClear_Click",this.cmdClear_Click);
this.bind("cmdPrint_Click",this.cmdPrint_Click);
this.bind("cmdClose_Click",this.cmdClose_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmNewQClass";
            }

            public loaded() {

            }

        

        public frmNewQClass_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmNewQClass",action:"frmNewQClass_Close"});
                e.preventDefault();
            }
            
        }
            public loadSpread(name: string) {
                var uniqueId = this.model.UniqueID;
                require(["spread"], (spread) => {
                    spread(name, uniqueId);
                });
            }
        public cboPrimary_SelectionChangeCommitted(sender: frmNewQClass, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboSecondary_SelectionChangeCommitted(sender: frmNewQClass, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboClass_SelectionChangeCommitted(sender: frmNewQClass, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdQuery_Click(sender: frmNewQClass, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClear_Click(sender: frmNewQClass, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdPrint_Click(sender: frmNewQClass, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClose_Click(sender: frmNewQClass, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

