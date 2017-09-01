(function () {
    'use strict';

    angular
        .module('PortfolioManagerApp')
        .controller('editModal', editModal);


    function editModal(item, $scope, $http) {

        
        $scope.model = {};
        $scope.model.Symbol = item.Symbol;
        $scope.model.SharesNumber = item.SharesNumber;
        $scope.model.ItemId = item.ItemId;


        activate();

        function activate() { }

        $scope.ok = function () {
            $scope.updatePortfolioItem($scope.model.ItemId, $scope.model.Symbol, $scope.model.SharesNumber)
        };


        $scope.updatePortfolioItem = function (id, symbol, sharesNumber) {
            var req = {
                method: 'PUT',
                url: 'http://localhost:7677/api/portfolioitems',
                params: {
                    Id: id
                },
                data: JSON.stringify({
                    ItemId: id,
                    Symbol: symbol,
                    SharesNumber: sharesNumber
                })
            }
            $http(req);
        };
    }
})();

