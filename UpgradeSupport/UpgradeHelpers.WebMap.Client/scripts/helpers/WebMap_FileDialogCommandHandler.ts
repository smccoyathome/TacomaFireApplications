/// <reference path="WebMap_Interfaces.ts" />


module WebMap.Client {

    export enum typeDialogCmd {
        cmdOpen = 1,
        cmdSave = 2
    }

    export class FileDialogCommandHandler implements ICommandHandler {
        public id = "filedialog";
        public dispatch(cmd: any) {
            FileDialogCommandHandler.generateDialog(cmd);

        }
        public static saveDialog(nid : string,args: string[]) {

            var templateFileDialog = "", namedlg = "dialog" + nid;

            templateFileDialog += "<div id=" + namedlg + " style= 'width: 250px'>";

            templateFileDialog += "<br>Enter file name:<br><br>";

            templateFileDialog += "&nbsp;&nbsp;&nbsp;&nbsp;<INPUT id='filename" + namedlg +"' TYPE='text' NAME= 'FileName' >";

            templateFileDialog += "<br><br><div class='dialog_buttons' >";

            templateFileDialog += "<input type='button' class='confirm_save k-button' value= 'Save' style= 'width: 70px' /> &nbsp;";
            templateFileDialog += "<input type='button' class='confirm_cancel k-button' value= 'Cancel' style= 'width: 70px' />";
            templateFileDialog += "</div>"


            templateFileDialog += "</div>";

            var w = $(templateFileDialog).kendoWindow(
                {
                    title: "Export File",
                    modal: true,
                    resizable: false
                }
            );

            var kendowWindow: kendo.ui.Window = w.data("kendoWindow");
            kendowWindow.center().open();

            var textFileName = $("#filename" + namedlg);

            var bSave = $('#' + namedlg + ' .confirm_save').kendoButton({
                enable: false,
                click: function (e) {
                    kendowWindow.close();
                    var dialogResult = "ok";
                    var dataURI_ = "data:text/plain;base64," + (<any>kendo).util.encodeBase64(args[0]);

                    var fileNameXML = textFileName.val();
                    var checkName = fileNameXML.toLowerCase();

                    if (checkName.indexOf(".xml") == -1) {
                        fileNameXML += ".xml"
                    }

                    (<any>kendo).saveAs({
                        dataURI: dataURI_,
                        fileName: fileNameXML
                    });

                //(<any>window).app.sendAction({ controller: "WebMapViewManager", action: "ResumePendingOperation", dialogResult: dialogResult, parameters: { requestedInput: { } } });
                }
            });

            $('#' + namedlg + ' .confirm_cancel').kendoButton({
                click: function (e) {
                    kendowWindow.close();
                    var dialogResult = "cancel";
                    //(<any>window).app.sendAction({ controller: "WebMapViewManager", action: "ResumePendingOperation", dialogResult: dialogResult, parameters: { requestedInput: { } } });
                }
            });


            textFileName.keyup(function () {
                (<any>bSave).data("kendoButton").enable($(this).val() != "")
            });

        }


        public static openDialog(nid  :string ,args: string[]) {

            var templateFileDialog = "";

            templateFileDialog += "<div id=dialog" + nid+">";

            templateFileDialog += "<p>File to import:</p>";

            templateFileDialog += "<input name='file'  id='" + nid + "' type='file'/>";

            templateFileDialog += "</div>";


            var w = $(templateFileDialog).kendoWindow(
                {
                    title: "Select File to Import",
                    modal: true,
                    resizable: false
                }
            );

            var kendowWindow: kendo.ui.Window = w.data("kendoWindow");
            kendowWindow.center().open();

            $("#" + nid + "").kendoUpload({
                multiple: false,
                showFileList: false,
                async: {
                    saveUrl: window.document.URL + "FileDialog/UploadFile",
                    autoUpload: true
                },
                select: function (e) {
                    //$.each(e.files, function (index, value) {
                    //});
                },
                success: function onSuccess(e) {
                    var js = JSON.parse(e.response);
                    var dialogResult = "ok";
                    (<any>window).app.sendAction({ controller: "WebMapViewManager", action: "ResumePendingOperation", dialogResult: dialogResult, parameters: { requestedInput: { filenames: js.fileName } } });
                },
                complete: function e(e) {
                    (<any>w).data('kendoWindow').close();
                    (<any>w).data('kendoWindow').destroy();
                }
            });
               
        }

        private static generateDialog(cmd: ICommand): void {
            var nid = "files" + Math.floor((Math.random() * 10000) + 1);

            switch (cmd.parameters.cmd) {
                case typeDialogCmd.cmdOpen:
                    FileDialogCommandHandler.openDialog(nid,cmd.parameters.args);
                    break;
                case typeDialogCmd.cmdSave:
                    FileDialogCommandHandler.saveDialog(nid, cmd.parameters.args);
                    break;
            }

        }

        static InitMessageBoxHandler() {
			if (CommandHandlerManager && CommandHandlerManager.Current) {
				CommandHandlerManager.Current.registerHandler("filedialog", new FileDialogCommandHandler());
				return null;
			}
        }

        static staticinit = FileDialogCommandHandler.InitMessageBoxHandler();


    }

}