/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmSplash", [ "files/text!views/PTSProject.frmSplash.html", "files/css!views/PTSProject.frmSplash.css"],
    (htmlTemplate) => {
    return class frmSplash extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
                $.proxy(this.onact, this)();
            }

            public bindings(){
            this.bind("frmSplash_KeyPress",this.frmSplash_KeyPress);
this.bind("Frame1_Click",this.Frame1_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmSplash";
            }

            public loaded() {
			
            }

        

        public frmSplash_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmSplash",action:"frmSplash_Close"});
                e.preventDefault();
            }
            
            }

        onact() {
            var that = this;
            return setTimeout(function () {
                that.close();
            }, 1000);
        }
        public frmSplash_KeyPress(sender: frmSplash, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "keyCode": e.keyCode}));            

        }
        public Frame1_Click(sender: frmSplash, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

