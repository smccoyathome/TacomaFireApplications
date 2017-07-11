/// <reference path="require.d.ts" />

module WebMap.Client {

    /**
     * Implements an ILogicView<T> interface.  
     * The typescript code for all forms must inherit from this class
     * Descendants must override the Init Method to sed the template to be used
     * 
     */
    export class BaseLogic implements ILogicView
    {
        static options = {
            template: kendo.template("template not loaded")
        }
        public ViewModel: any;
        private timersToCleanup: any[] = []; 

        /**
         * Gets the associated view from the ViewManage.LoadView (it could imply a web call) and then
         * calls BuildUI to initalize it
         */
        Init(isModal: boolean): void {
            // let's get the associated view from the ViewManager (it could imply a web call) and then
            // let's initalize it!
            this.BuildUI(BaseLogic.options.template, isModal);
        }

        /** 
         * Intializes the view elements using the given options
         * param template - The value of the template
        * param keyboardEvents - It's optional. Is used to validate whether the keyboard events should be added or not. True by default.
         */
        protected BuildUI(template: any, isModal: boolean, keyboardEvents?: boolean): void {

            template = template || kendo.template("<div>No template</div>");

            var appliedTemplate = template(this.ViewModel);

            var selector = this.ViewModel['Target'] || "#mainContent";

            //Appends the template to the page's DOM
            if (this.ViewModel['IsMdiParent']) {
                $(selector).replaceWith(appliedTemplate);
            }
            else
            {
                $(selector).append(appliedTemplate);

            }
            var domID = this.getDOMID();
            var element = $(domID);

            // If the window is not an MDI Parent then it will be rendered as a floating
            // window using the Kendo UI Window
            if (!this.ViewModel['IsMdiParent']) {
				
                var dynamicHTML = WebMap.Utils.DynamicContainer.applyTemplate(this.ViewModel, this.ViewModel.Controls);
				if (dynamicHTML != "") {
                    element.find("form").append(dynamicHTML);
				}

                var width = element.attr("data-width");
                var height = element.attr("data-height")
                var topValue = "0px";
                var titleValue = element.attr("data-title");

                if (element.attr("name") == "NoteAuthoring" || element.attr("name") == "AddClinicalItem" || element.attr("name") == "qChartDialog"){
                    topValue = "100px";
                }

                if (this.ViewModel.Text && this.ViewModel.Text != "" && this.ViewModel.Text != titleValue) {
                    titleValue = this.ViewModel.Text;
                    element.attr("data-title", titleValue);
                }

                var width = $(domID).attr("data-width");
                var height = $(domID).attr("data-height");
                var removeControlBox = $(domID).attr("data-removeControlBox");
                var actions;
                if (width && height) {
                    element.kendoWindow({
						modal: isModal, width: width, height: height, resizable: false, actions: ["Minimize", "Maximize", "Close"], position: <any>{ top: topValue }, title: titleValue, animation: {
							close: false,
							open: false
						}});
                }
                else {
                    element.kendoWindow({
						actions: ["Minimize", "Maximize", "Close"], title: titleValue, modal: isModal, animation: {
							close: false,
							open : false
						} });
                }
                //Adds a close event if not added at migration time
                var kendoInfo: any = element.data("kendoWindow");
                if (!kendoInfo) {
                    throw "Possible initialization error. A kendoWindow was expected but it was not found";
                }
                var that = this;
                if (kendoInfo && !kendoInfo._events || !kendoInfo._events.close) {
                    kendoInfo.bind("close", (e) => {
                        if (e.userTriggered) {
                            App.Current.ViewManager.CloseView(that.ViewModel);
                            e.preventDefault();
                        }
                    });
                }
                // fix an extra scrollbar in Chrome
                element.css("overflow", "hidden");
            }
            // binds the html element identified by gotten domID with the view model
            kendo.bind(element, this.ViewModel);
            //Set focus 
            $(domID + " *[tabindex=\"0\"]").first().focus();

            WebMap.Utils.bindEventToModel(this.ViewModel, "change", 
				(changeEvent) => this.ApplyValueChanges(changeEvent));

            //Keyboard Events (keydown,keypress,keyup)
            if (typeof (keyboardEvents) === "undefined" || keyboardEvents)
                this.KeyBoardEvents();
        }



        Close(): void {
            var domID = this.getDOMID();
			WebMap.Client.App.Current.isClosingView = true;
            if (!this.ViewModel['IsMdiParent']) {
				(<any>window).destroyCount = 0;
				var windowElement = $(domID);
                windowElement.data("kendoWindow").close();
				WebMap.Utils.selectiveUnbind(this.ViewModel);
                kendo.unbind(windowElement);
				setTimeout(function () {
					kendo.destroy(windowElement);
					$(domID).parent().empty();
					$(domID).parent().remove();
				}, 250);
            }
            else {
                window.close();
            }
			WebMap.Client.App.Current.isClosingView = false;
            this.CleanupTimers();
			StateManager.Current.ClearViewReferences(this.ViewModel.UniqueID);
        }




        public RegisterTimer(timerInfo: any) {
            this.timersToCleanup.push(timerInfo);
        }

        /**
         * This handler is meant to support convention based event handlers
         */
        public generic_Click(event): JQueryPromise<any> {
            if (event && event.data && event.target) {
                var options: AppActionOptions =
                    {
                        controller: event.data.Name.split(".").join("/"),
                        action: event.target.id + "_Click",
                        mainobj: <IStateObject>event.data
                    };
                App.Current.sendAction(options);
            }
            else {
                var def = $.Deferred();
                def.resolve();
                return def.promise();
            }
        }

        /**
          * Gets the id of the DOM object associated to the view
          */
        public getDOMID(): string {
            return "#" + this.ViewModel.UniqueID;
        }

        /**
         * Set keyboard events
         **/
        public KeyBoardEvents(): void {
            var id = $('#' + this.ViewModel.UniqueID);
            var kendoWindow = id.data("kendoWindow");

            if (id && kendoWindow) {
                id.keypress(function (e) {
                    kendoWindow.trigger("keypress", e)
                }).keydown(function (e) {
                    kendoWindow.trigger("keydown", e)
                }).keyup(function (e) {
                    kendoWindow.trigger("keyup", e)
                });
            }         
        }

        CloseWindowLocally(e): void {
            if (e.userTriggered) {
                var id = this.getDOMID();
                App.Current.ViewManager.CloseView(this.ViewModel);
            }
        }


        private CleanupTimers(): void {
            for (var i = 0; i < this.timersToCleanup.length; i++) {
                var timerInfo = this.timersToCleanup[i];
                if (timerInfo && timerInfo.clearTimer) {
                    timerInfo.clearTimer();
                }

            }
        }

        public ApplyEnabledPointerEvents = function (status) {
            $("#" + this.ViewModel.UniqueID).css("pointer-events", status);
           
            if ($("#" + this.ViewModel.UniqueID).children && $("#" + this.ViewModel.UniqueID).children.length > 0) {
                //disabled children events, some tags in html don't have enabled-disabled in children levels
                $("#" + this.ViewModel.UniqueID).find('*').css("pointer-events", status);
            }
        }

        private ApplyValueChanges = function (changeEvent) {
            var that = this;
            try {
                if (changeEvent.field === "Enabled") {
                    if (this.ViewModel.Enabled) {
                        $("#" + this.ViewModel.UniqueID).css("opacity", "1");
                        $("#" + this.ViewModel.UniqueID).removeProp("disabled");

                        this.ApplyEnabledPointerEvents('all')

                    }
                    else {
                        $("#" + this.ViewModel.UniqueID).css("opacity", "0.4");
                        $("#" + this.ViewModel.UniqueID).prop("disabled", "");

                        this.ApplyEnabledPointerEvents('none')

                    }
                }
                else if (changeEvent.field === "Visible") {
                    if (this.ViewModel.Visible) {
                        $("#" + this.ViewModel.UniqueID).css("visibility", "visible");
                    }
                    else {
                        $("#" + this.ViewModel.UniqueID).css("visibility", "hidden");
                    }
                }
            } catch (e)
            {
                window.app.log(e.message);
            }
        }


    }


}
