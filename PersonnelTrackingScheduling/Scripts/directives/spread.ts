/// <reference path="../typings/index.d.ts" />
define("spread",
    () => {
        return function load(name: string, uniqueId: string) {
            let http = window.app.inject.resolve("server");
            let data = {
                uniqueId: uniqueId,
                spreadName: name
            };

            http.post("spread/index",
                JSON.stringify(data),
                (response) => {
                    $("#" + name).kendoSpreadsheet(JSON.parse(response));
                    var spreadsheet = $("#" + name).data("kendoSpreadsheet");
                    var sheet = spreadsheet;
                    sheet.bind("change",
                        (e) => {
                            var data = {
                                uniqueId: uniqueId,
                                spreadName: name,
                                changes: []
                            };

                            e.range.forEachCell((row, column, value) =>
                                data.changes.push({ row: row, column: column, value: value }));
                            http.post("spread/change", JSON.stringify(data), () => {});

                        });
                });
        }
    });
