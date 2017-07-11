/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmIndivSchedNote", [ "files/text!views/PTSProject.frmIndivSchedNote.html", "files/css!views/PTSProject.frmIndivSchedNote.css"],
    (htmlTemplate) => {
    return class frmIndivSchedNote extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("cmdOK_Click",this.cmdOK_Click);
this.bind("cmdCancel_Click",this.cmdCancel_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmIndivSchedNote";
            }

            public loaded() {
			
            }

        

        public frmIndivSchedNote_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmIndivSchedNote",action:"frmIndivSchedNote_Close"});
                e.preventDefault();
            }
            
        }
        public cmdOK_Click(sender: frmIndivSchedNote, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdCancel_Click(sender: frmIndivSchedNote, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

