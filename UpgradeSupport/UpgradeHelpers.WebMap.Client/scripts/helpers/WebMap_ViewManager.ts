/// <reference path="require.d.ts" />

module WebMap.Client {

    export class ViewManager implements IViewManager {

        private _logic: { [viewModelUniqueID:string]: ILogicView};
        public closedViews: string[];

        constructor() {
            this._logic = {};
            this.closedViews = [];
        }

        GetView(UniqueID: string) {
            return <BaseLogic>this._logic[UniqueID];
        }

        CloseView(view: IViewModel) {
            window.app.sendAction({ mainobj: this, controller: "WebMapViewManager", action: "QueryClose", parameters: { viewId: view.UniqueID } });
        }

        PrepareDelta(requestInfo: WebMapRequest) {
            requestInfo.closedViews = this.closedViews;
        }

        UpdateView(view: IViewModel, viewInfo: any): void {
            var viewId = view.UniqueID;
            // if the view has been removed lets ignored the update process
            var isRemoved = this.IsRemovedView(viewId, viewInfo);
            if (!isRemoved) {
                // lets add the code to refresh the view state here
            }
        }

        RemoveViews(data): void {
            if (data.RemovedViews) {
                for (var i = 0; i < data.RemovedViews.length; i++) {
                    var viewModelId = data.RemovedViews[i];
                    this.DisposeView(viewModelId);
                }
            }
        }

        NavigateToView(viewModel: IViewModel, isModal: boolean): JQueryPromise<BaseLogic> {
            var def = $.Deferred<BaseLogic>();
            var viewManager = this;
			window.app.log("Navigating to " + viewModel.Name);
            require([viewModel.Name], function (baseLogicClass) {
                try {
                if (!baseLogicClass) {
                    console.error("ViewManager::NavigateToView. The baseLogicClass is undefined. Verify that the class constructor is being returned on your Form.ts file");
                    throw "Missing Form Client Code";
                }
                    window.app.log("Form Loaded");
                var logic = <BaseLogic>viewManager._logic[viewModel.UniqueID];
                if (!logic) {
                    logic = Container.Current.Resolve({ "cons": baseLogicClass });
                    viewManager._logic[viewModel.UniqueID] = logic;
                }
                logic.ViewModel = viewModel;
                (<any>viewModel).ViewModel = viewModel;
                (<any>viewModel).logic = logic;
                viewManager._logic[viewModel.UniqueID] = logic;
                logic.Init(isModal);
                } finally {
                def.resolve(logic);
                }
            });
            return def;
        }

        ShowMessage(message: string, caption: string, buttons, boxIcons): IPromise {
            return null;
        }

        private static DESIGNERSUPPORT: string = '<designersupport/>';

        public static removeDesignerSupportSnippet(document: string): string {
            var index = -1;
            if ((index = document.indexOf(ViewManager.DESIGNERSUPPORT)) != -1)
            {
                document = document.substring(index + ViewManager.DESIGNERSUPPORT.length);
            }
            return document;
        }

        /**
         * Safely compiles an html template for a view
         */
        public static CompileView(viewName: string, htmlTemplate: string) {
            var compiledTemplate;
            try {

                htmlTemplate = ViewManager.removeDesignerSupportSnippet(htmlTemplate);
                compiledTemplate = kendo.template(htmlTemplate);
            }
            catch (CompileException) {
                window.app.log("ViewManager::CompileView error compiling template [" + CompileException + "] for view [" + viewName + "]" );
                compiledTemplate = kendo.template("<div> Error </div>");
            }
            return compiledTemplate;
        }

        // Disposes the given view by removing the ILogicView object and calling its Close method.
        private DisposeView(viewModelId: string): void {
            var baseLogic = <BaseLogic>this._logic[viewModelId];
            if (baseLogic) {
            delete this._logic[viewModelId];
            baseLogic.Close();
        }

        }

        // Gets a lambda responsible for creating a new ILogicView<IViewModel> object for the given
        // view model
        public getConstructor(vm: IViewModel): () => ILogicView {
            var root = window;
            var current = null;
            if (vm.Name) {
                var name: string = vm.Name;
                if (name.indexOf('#') > 0) {
                    name = name.substring(name.indexOf('#') + 1);
                }
                var parts = name.split(".");
                for (var i = 0; i < parts.length; i++) {
                    var currentPart = parts[i];
                    if (root === undefined) {
                        throw "Error while looking for constructor of " + vm.Name + " possible cause is that the JS code for that class has not been loaded, if plugins used check if the script is processed";
                    }
                    current = root[currentPart];
                    root = current;
                }
            }
            return current;
        }

        // Checks that the given id is a removed view
        private IsRemovedView(id: string, VD): boolean {
            if (VD && VD.RemovedViews) {
                for (var i = 0; i < VD.RemovedViews.length; i++) {
                    if (VD.RemovedViews[i] == id)
                        return true;
                }
            }
            return false;
        }
    }
}
