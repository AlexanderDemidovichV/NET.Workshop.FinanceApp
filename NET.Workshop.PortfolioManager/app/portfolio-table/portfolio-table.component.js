(function() {
    'use strict';

    angular
        .module('PortfolioManagerApp')
        .component('portfolioTable', {
            templateUrl: 'app/portfolio-table/portfolio-table.template.html',
            controller: PortfolioTableController,
            controllerAs: 'vmPortfolioTable'
        });

    PortfolioTableController.$inject = ['PortfolioService', '$uibModal'];

    function PortfolioTableController(PortfolioService, $uibModal) {
        var vm = this;

        vm.documents = [];

        vm.deleteDocument = deleteDocument;
        vm.updateDocument = updateDocument;
        vm.getDocuments = getDocuments;
        vm.openEditForm = openEditForm;

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
            PortfolioService.update({ Id: item.LocalItemId}, item);
        };

        function deleteDocument(item){
            PortfolioService.delete({ Id: item.LocalItemId }, function () {
                getDocuments();
            });
        }

        function openEditForm() {
            var modalInstance = $uibModal.open({
                templateUrl: 'app/portfolio-table/edit-modal.template.html',
                controller: 'editModal'
            });
        }
    }
})();
