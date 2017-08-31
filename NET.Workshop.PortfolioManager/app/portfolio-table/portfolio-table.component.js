(function() {
    'use strict';

    angular
        .module('PortfolioManagerApp')
        .component('portfolioTable', {
            templateUrl: 'app/portfolio-table/portfolio-table.template.html',
            controller: PortfolioTableController,
            controllerAs: 'vmPortfolioTable'
        });

    PortfolioTableController.$inject = ['PortfolioService'];

    function PortfolioTableController(PortfolioService) {
        var vm = this;

        vm.documents = [];

        vm.deleteDocument = deleteDocument;
        vm.updateDocument = updateDocument;

        activate();

        function activate(){
            getDocuments();
        }

        function getDocuments() {
            PortfolioService.query(function(result){
                vm.documents = result;
            });
        }

        function updateDocument(item) {
            PortfolioService.update({Id: item.Id}, item);
        };

        function deleteDocument(item){
            PortfolioService.delete({Id: item.LocalItemId});

        }

    }
})();
