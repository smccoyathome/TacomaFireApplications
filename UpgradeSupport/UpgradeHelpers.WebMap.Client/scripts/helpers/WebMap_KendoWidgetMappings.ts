module WebMap.Utils {

    export class KendoWidgetMappings {

        private static _typeMappings: { [widgetName: string]: any; } =
        {
            'button': { 'CLICK': 'click' },
            'picturebox': { 'CLICK': 'click' },
            'ultrabutton': { 'CLICK': 'click' },
            'twtextbox': { 'TEXTCHANGED': 'change' },
            'menuitem': {'CLICK': 'click'}
        };

        public static getMappedEvent(widget: kendo.ui.Widget, eventID: string): string {
            var eventMapped: string = null;
            // widget
            var widgetName: string = widget.options['name'];
            //the keys are stored lower case.
            widgetName = widgetName.toLowerCase();
            var widgetMappings = this._typeMappings[widgetName];
            if (widgetMappings) {
                eventMapped = widgetMappings[eventID];
            }
            return eventMapped;
        }

        public static getMappedEventForMenuItem(widget: JQuery, eventID: string): string {
            var eventMapped: string = null;
            // widget
            var widgetName: string = widget.attr("role");
            if (widgetName) {
            //the keys are stored lower case.
            widgetName = widgetName.toLowerCase();
            var widgetMappings = this._typeMappings[widgetName];
            if (widgetMappings) {
                eventMapped = widgetMappings[eventID];
            }
            }
            return eventMapped;
        }
    }
} 