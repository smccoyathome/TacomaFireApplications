/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmMakeShiftAvailable", [ "files/text!views/PTSProject.frmMakeShiftAvailable.html", "files/css!views/PTSProject.frmMakeShiftAvailable.css"],
    (htmlTemplate) => {
    return class frmMakeShiftAvailable extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("calAvail_DateChanged",this.calAvail_DateChanged);
this.bind("cmdAvailDone_Click",this.cmdAvailDone_Click);
this.bind("cmdClose_Click",this.cmdClose_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmMakeShiftAvailable";
            }

            public loaded() {
			
            }

        

        public frmMakeShiftAvailable_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmMakeShiftAvailable",action:"frmMakeShiftAvailable_Close"});
                e.preventDefault();
            }
            
        }
        public calAvail_DateChanged(sender: frmMakeShiftAvailable, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdAvailDone_Click(sender: frmMakeShiftAvailable, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClose_Click(sender: frmMakeShiftAvailable, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

