/// <reference path="../typings/index.d.ts" />
define("spread", function () {
    return function load(name, uniqueId) {
        var http = window.app.inject.resolve("server");
        var data = {
            uniqueId: uniqueId,
            spreadName: name
        };
        http.post("spread/index", JSON.stringify(data), function (response) {
            $("#" + name).kendoSpreadsheet(JSON.parse(response));
            var spreadsheet = $("#" + name).data("kendoSpreadsheet");
            var sheet = spreadsheet;
            sheet.bind("change", function (e) {
                var data = {
                    uniqueId: uniqueId,
                    spreadName: name,
                    changes: []
                };
                e.range.forEachCell(function (row, column, value) {
                    return data.changes.push({ row: row, column: column, value: value });
                });
                http.post("spread/change", JSON.stringify(data), function () { });
            });
        });
    };
});
//# sourceMappingURL=spread.js.map