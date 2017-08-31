(function() {
    'use strict';

    angular
        .module('PortfolioManagerApp')
        .component('documentForm', {
            templateUrl: 'app/document-form/document-form.template.html',
            controller: DocumentFormController,
            controllerAs: 'vmDocumentForm'
        });

    DocumentFormController.$inject = ['PortfolioService'];

    function DocumentFormController(PortfolioService) {
      var vm = this;
      vm.onSubmit = onSubmit;
      vm.model = {}
      vm.options = {};
      vm.fields = [];

      activate();

      function activate(){
        vm.fields = [
          {
            key: 'symbol',
            type: 'input',
            templateOptions: {
              placeholder: 'Symbol',
              maxlength: '4',
              required: true
            }
          },
          {
            key: 'sharesNumber',
            type: 'input',
            templateOptions: {
              placeholder: 'Shares Number',
              type: 'number',
              maxlength: '9',
              required: true
            }
          }
        ];
      }

      function onSubmit() {
        PortfolioService.post(vm.model);
      }
    }
})();
