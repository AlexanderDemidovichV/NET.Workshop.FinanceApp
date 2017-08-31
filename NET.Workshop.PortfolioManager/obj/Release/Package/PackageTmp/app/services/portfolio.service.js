(function() {
    'use strict';

    angular
        .module('PortfolioManagerApp')
        .factory('PortfolioService', portfolioService);

    portfolioService.$inject = ['$resource'];

    function portfolioService($resource) {
        var service = $resource('http://localhost:7677/api/portfolioitems/:Id', {}, {
            query: {
							method: 'GET',
							params: {Id: ''},
							isArray: true
						},
						update: {
							method: 'PUT'
						},
						delete: {
							method: 'DELETE'
						},
						post: {
							method: 'POST'
						}
        });
        return service;

    }
})();
