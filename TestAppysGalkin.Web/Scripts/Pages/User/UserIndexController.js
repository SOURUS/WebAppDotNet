(function () {
    "use strict";

    angular
        .module('StoreApp', ['ngAnimate', 'ngRoute', 'ngDialog', 'commonModule', 'ui.bootstrap'])
        .controller('IndexController', IndexController)
        .factory('MessageService', MessageService)

    IndexController.$inject = ['$scope', 'ngDialog', '$filter', '$timeout', 'MessageService'];
    function IndexController($scope, ngDialog, $filter, $timeout, MessageService) {

        $scope.NewMessage = {
            ToUser: "",
            Text: ""
        };

        $scope.MessageBox = function () {
            ngDialog.openConfirm({
                template: 'MSBBOX',
                className: 'ngdialog-theme-option',
                closeByEscape: false,
                closeByDocument: false,
                showClose: false,
                scope: $scope,

                preCloseCallback: function () {
                    $scope.NewMessage = {
                        ToUser: "",
                        Text: ""
                    };
                },
            })
        };

        $scope.SendMessage = function () {
            MessageService.SendTheMessage($scope.NewMessage)
                .success(function (d) {
                    if (d.Text)
                        ngDialog.closeAll();
                    ngDialog.openConfirm({
                        template: 'informationDialog',
                        className: 'ngdialog-theme-option',
                        data: angular.toJson({
                            message: d.Text,
                        }),
                        closeByEscape: true,
                        trapFocus: false
                    })
                })
        };

        $scope.ReceivedMes = function () {
            MessageService.OwnMessages()
                .success(function (d) {
                    if (d.Data)
                        ngDialog.openConfirm({
                            template: 'MSBBOXVIEW',
                            className: 'ngdialog-theme-option',
                            closeByEscape: false,
                            closeByDocument: false,
                            showClose: false,
                            scope: $scope,
                            data: {
                                Flag: false, //принятые
                                Result: d.Data
                            }
                        })
                });
        };

        $scope.SentMes = function () {
            MessageService.SentMessage()
                .success(function (d) {
                    if (d.Data)
                        ngDialog.openConfirm({
                            template: 'MSBBOXVIEW',
                            className: 'ngdialog-theme-option',
                            closeByEscape: false,
                            closeByDocument: false,
                            showClose: false,
                            scope: $scope,
                            data: {
                                Flag:true, //отправленные
                                Result: d.Data
                            }
                        })
                });
        };


        $scope.closeDialog = function () {
            ngDialog.closeAll();
        };
    }

    MessageService.$inject = ['$http', 'ngDialog', 'commonModuleService'];
    function MessageService($http, ngDialog, common) {
        return {
            SendTheMessage: function (NewMessage) {
                return common.ngServiceCallWrapper($http.post('/User/SendMessage', { ToUserName: NewMessage.ToUser, msg: NewMessage.Text }), ngDialog)
            },
            OwnMessages: function () {
                return common.ngServiceCallWrapper($http.post('/User/ReceivedMessages'), ngDialog)
            },
            SentMessage: function () {
                return common.ngServiceCallWrapper($http.post('/User/SentMessage'), ngDialog)
            },
        };
    };
})();