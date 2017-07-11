/// <reference path="../helpers/WebMap.all.d.ts" />

if ((<any>window).kendo) {
    (function ($) {

        var DATABINDING = "dataBinding",
            DATABOUND = "dataBound",
            CHANGE = "change";

        // shorten references to variables. this is better for uglification
        var kendo = (<any>window).kendo,
            ui = kendo.ui,
            Widget = ui.Widget;
        var UpgradeHelpers_WebMap_Controls_ADODataControlHelper = ui.BaseUserControl.extend({
            initClientMethods: function (value) {
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

            },
            options: {
                // the name is what it will appear as off the kendo namespace(i.e. kendo.ui.WindowsFormsApplication1_UserControl1). 
                // The jQuery plugin would be jQuery.fn.kendoUserControl1. 
                name: "UpgradeHelpers_WebMap_Controls_ADODataControlHelper",
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
					background-image: url(\"/Resources/images/b_next.png\");\
					background-repeat: no-repeat;\
					background-position: center;\
					box-sizing: border-box;\
				}\
				#b_last{\
					float: left;\
					min-width: 18px;\
					width: 15%;\
					height: 100%;\
					background-image: url(\"/Resources/images/b_last.png\");\
					background-repeat: no-repeat;\
					background-position: center;\
					box-sizing: border-box;\
				}",
                // other options go here 
                template:
                "<div id=\"adodc\">\
					<input id=\"b_first\" type=\"button\" data-bind=\"events: { click: #= $$$parent #.logic.b_first_Click }\" />\
					<input id=\"b_prev\" type=\"button\" data-bind=\"events: { click: #= $$$parent #.logic.b_prev_Click }\" />\
					<input id=\"l_caption\" type=\"text\" data-bind=\" value: #= $$$parent #.Text \" readonly=\"true\" />\
					<input id=\"b_next\" type=\"button\" data-bind=\"events: { click: #= $$$parent #.logic.b_next_Click }\" />\
					<input id=\"b_last\" type=\"button\" data-bind=\"events: { click: #= $$$parent #.logic.b_last_Click }\" />\
				</div>"
            },

            // events are used by other widgets / developers - API for other purposes
            // these events support MVVM bound items in the template. for loose coupling with MVVM.
            events: [
            // call before mutating DOM.
            // mvvm will traverse DOM, unbind any bound elements or widgets
                DATABINDING,
            // call after mutating DOM
            // traverses DOM and binds ALL THE THINGS
                DATABOUND,
                CHANGE
            ]
        });
        ui.plugin(UpgradeHelpers_WebMap_Controls_ADODataControlHelper);
    })(jQuery);
}