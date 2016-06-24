(function () {
    "use strict";

    angular
        .module('commonModule', [])
        .factory('commonModuleService', commonModuleService)

    // обёртка для обработки ошибок в диалоговом окне
    commonModuleService.$inject = ['ngDialog'];
    function commonModuleService($http, ngDialog) {
        return {
            // успех
            ngServiceCallWrapper: function (item, ngDialog) {
                item.success(function (obj, status, headers, config) {
                });

                // обрабатываем ошибки
                item.error(function (data, status, headers, config) {
                    if (data.Message)
                        ngDialog.openConfirm({
                            template: 'informationDialog',
                            className: 'ngdialog-theme-option',
                            data: angular.toJson({
                                message: data.Message,
                            }),
                            closeByEscape: true,
                            trapFocus: false
                        })
                });
                return item;
            }
        };
    };
})();