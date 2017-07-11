module Mobilize.WebMap.Kendo {

    (<any>Mobilize).WebMap.Kendo.DragAndDropRegister.prototype.dragHandler =
        function(command: any) {
            const controlSelector = "#" + command.form + " #" + command.ControlName;
            var ele :any = $(controlSelector);
            if (ele.data("kendoDraggable") === (null || undefined)) {
                ele.kendoDraggable({
                    hint: function () {
                        return $(controlSelector).clone();
                    }
                });
            }
            var widget = ele.data("kendoDraggable");
            var event = (window as any).app.mouseDragEvent;
            if (event !== undefined && event !== null) {
                widget["userEvents"]._start(event);
            }
            else {
                console.log("The mouseDragEvent variable is not set. The dragging event cannot start.");
            }

    }
}