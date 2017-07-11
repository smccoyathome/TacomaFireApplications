/// <reference path="WebMap_Interfaces.ts" />
/// <reference path="../helpers/require.d.ts"/>

module WebMap.Client {

    declare var args: any;
    declare var appName: any;
    declare var glo_ptid: any;
    declare var glo_id: Array<any>;
    declare var glo_sWhere: any;
    declare var glo_sOrder: any;
    declare var glo_sGroup1: any;
    declare var glo_sGroup2: any;
    declare var glo_sPurpose: any;

    declare var glo_patientId: any;
    declare var glo_encounterId: any;

    declare var glo_WORKTYPE: string;
    declare var glo_WORKOBJECTID: string;

    //CreateNewDocument params
    declare var glo_selectedDocType: any;
    declare var glo_encDTTM: any;
    declare var glo_endID: any;
    declare var glo_patID: any;
    declare var glo_saveObject: any;
    declare var glo_sFormID: any;
    declare var glo_sOwnerFullName: any;
    declare var glo_dOwnerID: any;

    //Note unstructured
    declare var glo_isDocEdit: any;
    declare var glo_docId: any;
    declare var glo_sSubClass: any;
    declare var glo_bFromResume: any;



    export class InvokeActionCommandHandler implements ICommandHandler {

        public id = "invokeaction";

        public dispatch(cmd: any) {

            var requestedModule: any;
            requestedModule = cmd.parameters.args[0];

            switch (requestedModule) {

                case "PatientChange":
                    InvokeActionCommandHandler.PatientChange(cmd);
                    break;
                case "EncounterChange":
                    InvokeActionCommandHandler.EncounterChange(cmd);
                    break;
                case "PrintDialog":
                    InvokeActionCommandHandler.showHtmlDialog(cmd, "PrintDialog");
                    break;
                case "PrintChart":
                    InvokeActionCommandHandler.showHtmlDialog(cmd, "PrintChart");
                    break;
                case "TaskDialog":
                    InvokeActionCommandHandler.showHtmlDialog(cmd, "TaskDialog");
                    break;
                case "CreateNewDocument":
                    InvokeActionCommandHandler.showHtmlDialog(cmd, "CreateNewDocument");
                    break;
                case "SetDocumentContext":
                    InvokeActionCommandHandler.SetDocumentForNote(cmd);
                    break;
                case "SpellChecker":
                    InvokeActionCommandHandler.SpellCheckV11(cmd);
                    break;
                case "UpdateMacros":
                    InvokeActionCommandHandler.MacrosChange(cmd);
                    break;
                case "ChangeContextNavigator":
                    InvokeActionCommandHandler.ChangeContextNavigator(cmd);
                    break;
                default:
                    console.log("Invoke action handler pending");
                    break;
               
            }
        }

        private static SpellCheckV11(cmd: ICommand): void {
            
            $.getScript("scripts/frontpage/WebWorks/notev11.spellcheck.js");

        }

        private static SetDocumentForNote(cmd: ICommand): void {

            glo_isDocEdit = true;

            glo_docId = cmd.parameters.args[1];
            glo_sSubClass = cmd.parameters.args[2];
            glo_bFromResume = false;

        }

        private static ChangeContextNavigator(cmd: ICommand): void {
            $.getScript("scripts/frontpage/ContextNavigatorChangeManagers.js");
            (<any>window).app.sendAction({ controller: "WebMapViewManager", action: "ResumePendingOperation", dialogResult: "ok", parameters: { requestedInput: "" } });
        }

        private static PatientChange(cmd: ICommand): void {

            glo_patientId = cmd.parameters.args[1];
            $.getScript("scripts/frontpage/PatientContextChangeManager.js");
            (<any>window).app.sendAction({ controller: "WebMapViewManager", action: "ResumePendingOperation", dialogResult: "ok", parameters: { requestedInput: "" } });
        }

        private static EncounterChange(cmd: ICommand): void {

            glo_encounterId = cmd.parameters.args[1];
            $.getScript("scripts/frontpage/EncounterContextChangeManager.js");
            (<any>window).app.sendAction({ controller: "WebMapViewManager", action: "ResumePendingOperation", dialogResult: "ok", parameters: { requestedInput: "" } });
        }
        private static MacrosChange(cmd: ICommand): void {

            args = cmd.parameters.args.join(",");
            $.getScript("scripts/frontpage/MacrosChangeManager.js");
            (<any>window).app.sendAction({ controller: "WebMapViewManager", action: "ResumePendingOperation", dialogResult: "ok", parameters: { requestedInput: "" } });
        }


        private static showHtmlDialog(cmd: ICommand, screen: string): void {

            args = cmd.parameters.args.join(",");
            appName = cmd.parameters.appName;
            glo_ptid = cmd.parameters.args[1];
            glo_id = [cmd.parameters.args[2], ""];

            glo_sWhere = cmd.parameters.args[3];
            glo_sOrder = cmd.parameters.args[4];
            glo_sGroup1 = cmd.parameters.args[5];
            glo_sGroup2 = cmd.parameters.args[6];
            glo_sPurpose = cmd.parameters.args[8];
            var dialogResult = "ok";



            switch (screen) {
                case "PrintDialog":
                    //Mobilize.MLO: Script injection for subsecuent management of script loading.     
                    $.getScript("scripts/frontpage/InvokeActionManager.js");
                    break;
                case "TaskDialog":
                    {
                        glo_WORKTYPE = cmd.parameters.args[2];
                        glo_WORKOBJECTID = cmd.parameters.args[3];
                        glo_patientId = cmd.parameters.args[5];

                        $.getScript("scripts/frontpage/InvokeActionTaskList.js");
                        (<any>window).app.sendAction({ controller: "WebMapViewManager", action: "ResumePendingOperation", dialogResult: dialogResult, parameters: { requestedInput: "" } });
                    }
                    break;
                case "CreateNewDocument":
                    {
                        glo_selectedDocType = cmd.parameters.args[1];
                        glo_encDTTM = cmd.parameters.args[2];
                        glo_endID = cmd.parameters.args[3];
                        glo_patID = cmd.parameters.args[4];
                        glo_saveObject = cmd.parameters.args[5];
                        glo_sFormID = cmd.parameters.args[6];
                        glo_sOwnerFullName = cmd.parameters.args[7];
                        glo_dOwnerID = cmd.parameters.args[8];

                        (<any>window).app.sendAction({ controller: "WebMapViewManager", action: "ResumePendingOperation", dialogResult: dialogResult, parameters: { requestedInput: "" } });
                    }
                    break;
                default:
                    $.getScript("scripts/frontpage/InvokeActionManager.js");

                    break;

            }
        }



        static InitInvokeActionHandler() {
            CommandHandlerManager.Current.registerHandler("invokeaction", new InvokeActionCommandHandler());
            return null;
        }

        static staticinit = InvokeActionCommandHandler.InitInvokeActionHandler();


    }

}