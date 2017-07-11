(function ($, undefined) {




    // shorten references to variables. this is better for uglification
    var ui = kendo.ui, Widget = ui.Widget, ListView = ui.ListView;

    var ListBox = ListView.extend({

        // method called when a new kendoYouTube widget is created
        init: function (element, options) {

            var that = this;
            if (!options.template) {
                options.selectable = options.selectable || true;
                var _textField = element.getAttribute("data-text-field") || "Text";
                var _textValue = element.getAttribute("data-text-value");

                if (_textField && !_textValue) {
                    var templateKey = "@@listboxtemplate_" + _textField;
                    if (!window[templateKey]) {
                        var templateText = kendo.format("<div style='width:100%;height:20px;display:inline-block;overflow-x:hidden'>#={0}#</div>", _textField);
                        window[templateKey] = kendo.template(templateText);
                    }
                    options.template = window[templateKey];
                }
                if (_textField && _textValue) {
                    var templateKey = "@@listboxtemplate_" + _textField + _textValue;
                    if (!window[templateKey]) {
                        var templateText = kendo.format("<div style='width:100%;height:20px;display:inline-block;overflow-x:hidden'>#={0}#</div>", _textField);
                        window[templateKey] = kendo.template(templateText);
                    }
                    options.template = window[templateKey];
                }
            }


            ListView.fn.init.call(that, element, options);
        },

        // options that are avaiable to the user when initializing the widget
        options: {
            name: "ListBox"
        }
    });


    var CheckedListBox = ListView.extend({
        init: function (element, options) {
            var that = this;
            if (!options.template) {
                options.selectable = options.selectable || true;
                var _textField = element.getAttribute("data-text-field") || "Text";
                var _textValue = element.getAttribute("data-text-value");

                if (_textField && !_textValue) {
                    var templateKey = "@@checklistboxtemplate_" + _textField;
                    if (!window[templateKey]) {
                        var templateText = kendo.format("<div style='width:100%;height:20px;display:inline-block;overflow-x:hidden'><input type='checkbox' onclick='WebMap.Client.checkedListBoxProc(this)' />#={0}#</div>", _textField);
                        window[templateKey] = kendo.template(templateText);
                    }
                    options.template = window[templateKey];
                }
                if (_textField && _textValue) {
                    var templateKey = "@@checklistboxtemplate_" + _textField + _textValue;
                    if (!window[templateKey]) {
                        var templateText = kendo.format("<div style='width:100%;height:20px;display:inline-block;overflow-x:hidden'><input type='checkbox' onclick='WebMap.Client.checkedListBoxProc(this)' />#={0}#</div>", _textField);
                        window[templateKey] = kendo.template(templateText);
                    }
                    options.template = window[templateKey];
                }
            }


            ListView.fn.init.call(that, element, options);
        },

        // options that are avaiable to the user when initializing the widget
        options: {
            name: "CheckedListBox",
            checkOnClick: false,
        },
    });

    ui.plugin(ListBox);
    ui.plugin(CheckedListBox);
})(window.kendo.jQuery);