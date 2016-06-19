//Component for each user's schedules
(function () {
    'use strict';

    angular
        .module('app')
        .component('taskContainer', {
            templateUrl: '/App/directives/taskContainer/taskContainer.html',
            controller: taskContainerController,
            bindings: {
                headerDisplay:'<',
                taskData: '<',
            }
        });

    function taskContainerController(companyFactory) {
        var ctrl = this;
    }

})();