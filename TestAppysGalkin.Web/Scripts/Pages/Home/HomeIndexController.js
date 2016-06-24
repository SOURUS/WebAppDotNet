(function () {
    "use strict";

    angular
        .module('StoreApp', ['ngAnimate', 'ngRoute', 'ngDialog', 'commonModule', 'ui.bootstrap', 'nya.bootstrap.select', 'angularUtils.directives.dirPagination', 'ui-rangeSlider'])
        .controller('IndexController', IndexController)
        .factory('ProductService', ProductService)
        .provider('appConfig', appConfigProvider)
        
    function appConfigProvider() {
        var config = {};
        return {
            set: function (values) {
                angular.extend(config, values);
            },
            $get: function () { return config; }
        };
    };

    IndexController.$inject = ['$scope', 'ngDialog', '$filter', '$timeout', 'appConfig', 'ProductService'];
    function IndexController($scope, ngDialog, $filter, $timeout, config, ProductService) {

        $scope.Producers = config.Model.Data;   // список производителей
        $scope.Result = [];                     // список найденных товаров
        $scope.SliderSetting =                  // настройки для прайс-слайдера
        {
            min: 0,
            max: 50000,
            step: 100
        };

        $scope.Product_InfoSearch = {           // фильтр поиска наушников
            Price: {
                minValue: 0,
                maxValue: 99999,
            },
            SelectedProcedures: [],
            DynamicQuantity: null,
            isPortable: [],
        };

        $scope.FindResult = function () {
            ProductService.getProducts()
            .success(function (d) {
                $scope.Result = d.Data;          //получаем "замаппенный" список наушников
                SetPaging();
            })
        };
        
        $scope.FindResult();                    //Загрузим данные сразу при загрузке страницы

        $scope.viewby = [4];                    // все для клиентского пэйджинга
        $scope.Paging = null;
        $scope.Variants = [4, 8, 100];

        function SetPaging() {
            $scope.Paging = {
                totalItems: $scope.Result.length,
                itemsPerPage: $scope.viewby,
                currentPage: 1
            };
        };

        SetPaging();
        $scope.setItemsPerPage = function (num) {
            $scope.Paging.itemsPerPage = num;
            $scope.Paging.currentPage = 1;
        };

        $scope.HeadPhoneFilter = function (item) {    //фильтруем наши "уши" по параметрам Product_InfoSearch
            if (item.Price < $scope.Product_InfoSearch.Price.minValue || item.Price > $scope.Product_InfoSearch.Price.maxValue)
                return false;

            if ($scope.Product_InfoSearch.SelectedProcedures.length > 0)
                if (jQuery.grep($scope.Product_InfoSearch.SelectedProcedures, function (dt) { return dt == item.Producer.ProducerId }).length<=0)
                    return false;

            if ($scope.Product_InfoSearch.DynamicQuantity != null && $scope.Product_InfoSearch.DynamicQuantity != item.HeadPhone.DynamicQuantity)
                return false;

            if ($scope.Product_InfoSearch.isPortable.length > 0)
                if (jQuery.grep($scope.Product_InfoSearch.isPortable, function (dt) { return dt == item.HeadPhone.IsPortable }).length <= 0)
                    return false;

            return true;
        };

        $scope.GoOrder = function (item) {          // Don't even try..
            ProductService.MachDieAuftrag(item);
        };
    }

    ProductService.$inject = ['$http', 'ngDialog', 'commonModuleService'];
    function ProductService($http, ngDialog, common) {
        return {
            getProducts: function (filter) {
                return common.ngServiceCallWrapper($http.post('/Home/GetProducts'), ngDialog)
            },

            MachDieAuftrag: function (Product) {
                return common.ngServiceCallWrapper($http.post('/Home/MakeOrder', { Product: Product }), ngDialog)
            },
            
        };
    };

})();