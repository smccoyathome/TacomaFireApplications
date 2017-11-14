/// <reference path="../typings/index.d.ts" />
/*************************************************************************
*
* MOBILIZE CONFIDENTIAL
* _______________________________________________________________________
*
*  Mobilize Company
*  All Rights Reserved.
*
* NOTICE: All helper classes are provided for customer use only;
* all other use is prohibited without prior written consent from Mobilize.Net.
* no warranty express or implied;
* use at own risk.
**************************************************************************/
module Mobilize.Ifgs {
    import Bind = kendo.bind;

    export class CustomGrid extends kendo.ui.Grid {

        private subscriptions: any;
        public isUpdating: boolean;

        /**
         * /
         * Propertie selectable values accepted Handle the Selection Mode of the grid 
            - true (enables row selection)
            - row
            - cell
            - multiple, row
            - multiple, cell
         * Propertie groupable accept true or false , default option false 
         */

        constructor(element: Element, options?: kendo.ui.GridOptions) {
            var selectable = element.attributes["grid-selectable"];
            var groupable = element.attributes["grid-group"];
            options.resizable = true;
            options.scrollable = true;
            options.groupable = groupable ? groupable.value: false;
            options.selectable = selectable ? selectable.value : "row"; 
            options.navigatable = true;
            options.pageable = true;
            options.editable = false;
            super(element, options);
            this.setNewEvents();
            this.subscriptions = [];
            this.isUpdating = false;
        }


        public visible(value: any) {
            if (value) {
                $(this.element).css("display", "");
            } else {
                $(this.element).css("display", "none");
            }
        }


        // CustomGridId
        private _gridUID: string;

        // Gets the GridUId
        get gridUID(): string {
            return this._gridUID;
        }

        // Sets the GridUid
        set gridUID(value: string) {
            this._gridUID = value;
        }
        public subscribe(binding: string, fn: any) {
            this.subscriptions[binding] = fn;
        }

        private setNewEvents() {
            var that = this;
            var grid = this.element as any;
            this.events = this.events.concat(["afterCellActivate, " +
                "afterColPosChanged, afterCellUpdate," +
                "afterColRegionScroll, afterRowRegionScroll," +
                "afterRowUpdate, afterRowActivate," +
                "beforeCellActivate, beforeColRegionScroll, beforeEnterEditMode," +
                "beforeRowDeactivate, beforeRowRegionScroll, cellChange, doubleClick" +
                "beforeExitEditMode ,mousedown, mouseup, keypress, keydown, blur"]);
            this.bind('change', event => this.triggerCellActivateEvents(event));
            this.bind('columnResize', event => this.triggerAfterColPosChanged(event));
            this.bind('columnReorder', event => this.triggerAfterColPosChanged(event));
            this.bindJSEvents();
        }

        public bindJSEvents() {
            var that = this;

            var content = $(this.element).find('.k-grid-content')[0];
            $(content).scroll((e: any) => {
                if (e.currentTarget.scrollLeft) {
                    that.trigger("beforeColRegionScroll");
                    that.trigger('afterColRegionScroll');
                }
                else {
                    that.trigger("beforeRowRegionScroll");
                    that.trigger('afterRowRegionScroll');
                }
            });
            this.bindMouseEvents();
        }

        //bind mouse events
        public bindMouseEvents() {
            var that = this;
            var grid = this.element as any;
            setTimeout(() => {
                var table = $(grid).find('table');
                $(table).attr('tabindex', 0);
                $(table).unbind('dblclick');
                $(table).bind('dblclick', () => {that.trigger("doubleClick");});
                $(table).find('tr').unbind('mousedown');
                $(table).find('tr').bind('mousedown', () => {
                    that.trigger("mousedown");
                });
                $(table).find('tr').unbind('mouseup');
                $(table).find('tr').bind('mouseup', () => {
                    that.trigger("mouseup");
                });
                $(table).unbind('keypress');
                $(table).bind('keypress', (e) => {
                    that.trigger("keypress", e);
                });
                $(table).unbind('keydown');
                $(table).bind('keydown', (e) => {
                    that.trigger("keydown", e);
                });
            }, 100);

        }


        ///Triggers afterCellActivateEvent
        private triggerAfterCellActivate(event): void {
            if (!this.isUpdating) {
                this.trigger('afterCellActivate');
            }
        }

        ///Triggers afterRowActivateEvent
        private triggerAfterRowActivate(event): void {
            if (!this.isUpdating) {
                this.trigger('afterRowActivate');
            }
        }

        ///Triggers afterColPosChanged
        private triggerAfterColPosChanged(event): void {
            if (!this.isUpdating) {
                this.trigger('afterColPosChanged');
            }
        }


        ///Triggers beforeCellActivate
        private triggerBeforeCellActivate(event): void {
            if (!this.isUpdating) {
                this.trigger('beforeCellActivate');
            }
        }

        private triggerBeforeRowDeactivate(event): void {
            if (!this.isUpdating) {
                this.trigger('beforeCellActivate');
            }
        }

        private triggerCellActivateEvents(event) {
            this.triggerBeforeRowDeactivate(event);
            this.triggerBeforeCellActivate(event);
            this.triggerAfterCellActivate(event);
            this.triggerAfterRowActivate(event);
        }
    }


}

Mobilize.WebMap.Kendo.Widget.plugin(Mobilize.Ifgs.CustomGrid, "customgrid");