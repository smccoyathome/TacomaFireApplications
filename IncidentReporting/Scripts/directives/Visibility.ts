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
module kendo.data.binders.widget {
    export class Visibility extends Binder {

        constructor(element: Element, bindings: { [key: string]: Binding; }, options?: any) {
            super(element, bindings, options);
            if (this.element.subscribe) {
                this.element.subscribe("Visibility", (value) => this.bindings["Visibility"].set(value));
            }
        }

       public refresh(): void {

            if (this.element.visible) {
                this.element.visible(this.bindings["Visibility"].get());
            }
        }
    }

}