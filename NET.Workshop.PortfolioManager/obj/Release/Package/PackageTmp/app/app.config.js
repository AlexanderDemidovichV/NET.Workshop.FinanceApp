(function(){
  'use strict';

  angular.
    module('PortfolioManagerApp').
    config(config);

  config.$inject = ['$locationProvider', '$stateProvider', '$urlRouterProvider', 'blockUIConfig'];

  function config($locationProvider, $stateProvider, $urlRouterProvider, blockUIConfig){
    blockUIConfig.autoBlock = true;
    blockUIConfig.resetOnException = true;
    blockUIConfig.message = 'Please wait';

    $locationProvider.hashPrefix("");
    $locationProvider.html5Mode(true);

    $urlRouterProvider.otherwise("/");

    $stateProvider
      .state('portfolio', {
        url: "/",
        views: {
          '': {
            templateUrl: 'app/state.template/portfolio-table.state.template.html'
          }
        }
      });
  }

})();

