(function () {
    "use strict";

    angular
        .module('SinglrModule', [])
        .factory('SignalrSvc', SignalrSvc, ['$rootScope', '$q'])

    angular.module('SinglrModule').value('$', $);

    SignalrSvc.$inject = ['$rootScope', '$q'];
    function SignalrSvc($rootScope, $q) {
        return {
            promises: [],
            proxy: null,

            init: function () {
                $.connection.hub.logging = true;
                var d = $q.defer();
                this.promises.push($.connection.hub.start())
                this.proxy = $.connection.MainHub;

                this.proxy.on('updateMessages', function (message) {
                    $rootScope.$emit("updateMessages", message);
                });

                return this.promises;
            },

            sendRequest: function () {
                //Invoking greetAll method defined in hub
                this.proxy.invoke('greetAll');
            }
        }
    }
})();