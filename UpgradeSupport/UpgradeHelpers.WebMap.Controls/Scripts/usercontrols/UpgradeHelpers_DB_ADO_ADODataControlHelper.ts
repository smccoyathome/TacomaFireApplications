/// <reference path="../helpers/WebMap.all.d.ts" />
/// <reference path="../helpers/require.d.ts" />

define("usercontrols/UpgradeHelpers_DB_ADO_ADODataControlHelper",
    [], function () {
        var ui = kendo.ui;
        /**
         * WebMap implementation for an equivalent of the VB6 ADO DataControl
         * The UI provides four buttons FIRST, NEXT, PREVIOUS, LAST and
         * can also display some text
         */
        class UpgradeHelpers_DB_ADO_ADODataControlHelper {

            /**
             * Handler for each of the buttons are connected to the widget here
             */
            initClientMethods(value: any) {
                var that = value;
                value.logic = {};
                value.logic.b_first_Click = function (e: any) {
                    return window.app.sendAction({ mainobj: that, controller: "ADODataControlHelper", action: "b_first_Click" });
                };
                value.logic.b_prev_Click = function (e: any) {
                    return window.app.sendAction({ mainobj: that, controller: "ADODataControlHelper", action: "b_prev_Click" });
                };
                value.logic.b_next_Click = function (e: any) {
                    return window.app.sendAction({ mainobj: that, controller: "ADODataControlHelper", action: "b_next_Click" });
                };
                value.logic.b_last_Click = function (e: any) {
                    return window.app.sendAction({ mainobj: that, controller: "ADODataControlHelper", action: "b_last_Click" });
                };

            }
            options = {
                /** the name is what it will appear as off the kendo namespace(i.e. kendo.ui.WindowsFormsApplication1_UserControl1). 
                  * The jQuery plugin would be jQuery.fn.kendoUserControl1.
                  */
                name: "UpgradeHelpers_DB_ADO_ADODataControlHelper",
                value: null,
                css:
                "#adodc{\
					height: 100%;\
					width: 100%;\
				}\
				#b_first{\
					float: left;\
					min-width: 18px;\
					width: 15%;\
					height: 100%;\
					background-image: url(\"/Resources/images/b_first.png\");\
					background-repeat: no-repeat;\
					background-position: center;\
					box-sizing: border-box;\
				}\
				#b_prev{\
					float: left;\
					min-width: 18px;\
					width: 15%;\
					height: 100%;\
					background-image: url(\"/Resources/images/b_prev.png\");\
					background-repeat: no-repeat;\
					background-position: center;\
					box-sizing: border-box;\
				}\
				#l_caption{\
					float: left;\
					width: 40%;\
					height: 100%;\
					border: hidden;\
					text-align: center;\
					vertical-align: middle;\
				}\
				#b_next{\
					float: left;\
					min-width: 18px;\
					width: 15%;\
					height: 100%;\
					background-image: url(\"/resources/images/b_next.png\");\
					background-repeat: no-repeat;\
					background-position: center;\
					box-sizing: border-box;\
				}\
				#b_last{\
					float: left;\
					min-width: 18px;\
					width: 15%;\
					height: 100%;\
					background-image: url(\"/resources/images/b_last.png\");\
					background-repeat: no-repeat;\
					background-position: center;\
					box-sizing: border-box;\
				}",
                template:
                "<div id=\"adodc\">\
					<input id=\"b_first\" type=\"button\" data-bind=\"events: { click: #= $$$parent #.logic.b_first_Click }\" />\
					<input id=\"b_prev\" type=\"button\" data-bind=\"events: { click: #= $$$parent #.logic.b_prev_Click }\" />\
					<input id=\"l_caption\" type=\"text\" data-bind=\" value: #= $$$parent #.Text \" readonly=\"true\" />\
					<input id=\"b_next\" type=\"button\" data-bind=\"events: { click: #= $$$parent #.logic.b_next_Click }\" />\
					<input id=\"b_last\" type=\"button\" data-bind=\"events: { click: #= $$$parent #.logic.b_last_Click }\" />\
				</div>"
            }
        }
        var ancestor = (<any>ui).BaseUserControl;
        ui.plugin((<any>ui).BaseUserControl.extend(new UpgradeHelpers_DB_ADO_ADODataControlHelper()));
    });