/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmEmployeeNotes", [ "files/text!views/PTSProject.frmEmployeeNotes.html", "files/css!views/PTSProject.frmEmployeeNotes.css"],
    (htmlTemplate) => {
    return class frmEmployeeNotes extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("cmdClose_Click",this.cmdClose_Click);
this.bind("cmdNewNote_Click",this.cmdNewNote_Click);
this.bind("cboEmpList_SelectionChangeCommitted",this.cboEmpList_SelectionChangeCommitted);
this.bind("cmdAddUpdate_Click",this.cmdAddUpdate_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmEmployeeNotes";
            }

            public loaded() {

            }

        

        public frmEmployeeNotes_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmEmployeeNotes",action:"frmEmployeeNotes_Close"});
                e.preventDefault();
            }
            
        }
        public cmdClose_Click(sender: frmEmployeeNotes, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdNewNote_Click(sender: frmEmployeeNotes, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboEmpList_SelectionChangeCommitted(sender: frmEmployeeNotes, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdAddUpdate_Click(sender: frmEmployeeNotes, action: string, e: any) {
            
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

