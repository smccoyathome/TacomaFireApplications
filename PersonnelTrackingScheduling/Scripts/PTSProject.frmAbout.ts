/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmAbout", [ "files/text!views/PTSProject.frmAbout.html", "files/css!views/PTSProject.frmAbout.css"],
    (htmlTemplate) => {
    return class frmAbout extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("cmdOK_Click",this.cmdOK_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmAbout";
            }

            public loaded() {
			
            }

        

        public frmAbout_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmAbout",action:"frmAbout_Close"});
                e.preventDefault();
            }
            
        }
        public cmdOK_Click(sender: frmAbout, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

