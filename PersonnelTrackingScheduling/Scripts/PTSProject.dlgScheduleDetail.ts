/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.dlgScheduleDetail", [ "files/text!views/PTSProject.dlgScheduleDetail.html", "files/css!views/PTSProject.dlgScheduleDetail.css"],
    (htmlTemplate) => {
    return class dlgScheduleDetail extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("OKButton_Click",this.OKButton_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "dlgScheduleDetail";
            }

            public loaded() {

            }

        

        public dlgScheduleDetail_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"dlgScheduleDetail",action:"dlgScheduleDetail_Close"});
                e.preventDefault();
            }
            
        }
            public loadSpread(name: string) {
                var uniqueId = this.model.UniqueID;
                require(["spread"], (spread) => {
                    spread(name, uniqueId);
                });
            }
        public OKButton_Click(sender: dlgScheduleDetail, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

