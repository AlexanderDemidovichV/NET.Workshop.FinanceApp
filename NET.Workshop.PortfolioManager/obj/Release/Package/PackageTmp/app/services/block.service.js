(function() {
    'use strict';

    angular
        .module('PortfolioManagerApp')
        .service('BlockUiService', BlockUiServiceController);

    BlockUiServiceController.$inject = ['blockUI'];

    function BlockUiServiceController(blockUI) {
    	var mainBlock = blockUI.instances.get("mainBlock");
        this.start = startBlock;
        this.stop = stopBlock;

        ////////////////

        function startBlock() {
        	mainBlock.start();
        }

        function stopBlock() {
        	mainBlock.stop();
        }

    }
})();

