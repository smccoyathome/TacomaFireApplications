/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.dlgCalendarYearShift", [ "files/text!views/PTSProject.dlgCalendarYearShift.html", "files/css!views/PTSProject.dlgCalendarYearShift.css"],
    (htmlTemplate) => {
    return class dlgCalendarYearShift extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("cmdExit_Click",this.cmdExit_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "dlgCalendarYearShift";
            }

            public loaded() {

            }

        

        public dlgCalendarYearShift_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"dlgCalendarYearShift",action:"dlgCalendarYearShift_Close"});
                e.preventDefault();
            }
            
        }
        public cmdExit_Click(sender: dlgCalendarYearShift, action: string, e: any) {
            
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

