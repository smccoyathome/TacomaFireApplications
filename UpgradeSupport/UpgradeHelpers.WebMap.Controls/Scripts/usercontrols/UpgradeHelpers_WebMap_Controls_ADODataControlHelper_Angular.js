if (window.angular) {
    window.angular.
        module("mainApp").
        directive("adoDataControlHelper", ["webmapapp",
        function (webmapapp) {
            return {
                restrict: "A",
                scope: {
                    value: "="
                },
                template: "<div id=\"adodc\">\
                    <button ng-click=\"b_first_Click()\" ><span class=\"glyphicon glyphicon-fast-backward\" aria-hidden=\"true\"></span></button>\
                    <button ng-click=\"b_prev_Click()\"><span class=\"glyphicon glyphicon-backward\" aria-hidden=\"true\"></span></button>\
                    <input id=\"l_caption\" type=\"text\" ng-model=\"Text\" readonly=\"true\"/>\
                    <button ng-click=\"b_next_Click()\" ><span class=\"glyphicon glyphicon-forward\" aria-hidden=\"true\"></span></button>\
                    <button ng-click=\"b_last_Click()\" ><span class=\"glyphicon glyphicon-fast-forward\" aria-hidden=\"true\"></span></button>\
                </div>",
                link: function (scope) {
                    scope.b_first_Click = function () {
                        return webmapapp.sendAction({
                            vmid: scope.value.UniqueID,
                            controller: "ADODataControlHelper",
                            action: "b_first_Click"
                        });
                    };
                    scope.b_prev_Click = function () {
                        return webmapapp.sendAction({
                            vmid: scope.value.UniqueID,
                            controller: "ADODataControlHelper",
                            action: "b_prev_Click"
                        });
                    };
                    scope.b_next_Click = function () {
                        return webmapapp.sendAction({
                            vmid: scope.value.UniqueID,
                            controller: "ADODataControlHelper",
                            action: "b_next_Click"
                        });
                    };
                    scope.b_last_Click = function () {
                        return webmapapp.sendAction({
                            vmid: scope.value.UniqueID,
                            controller: "ADODataControlHelper",
                            action: "b_last_Click"
                        });
                    };
                }
            };
        }]);
}
//# sourceMappingURL=UpgradeHelpers_WebMap_Controls_ADODataControlHelper_Angular.js.map