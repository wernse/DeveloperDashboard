//Component for tasks within a schedule
(function () {
    'use strict';

    angular
        .module('app')
        .component('taskBox', {
            templateUrl: '/App/directives/task/task.html',
            controller: ['companyFactory', taskController],
            bindings: {
                data: '<'
            }
        });

    function taskController(companyFactory) {
        var ctrl = this;
        ctrl.colour = findColour(ctrl.data.CompanyId);

        //finds colours from companymap, no point having a binding as it is coupled with companyid
        function findColour(companyId) {
            var companyMap = companyFactory.companyMap;
            console.log(companyMap[companyId]);
            return companyMap[companyId];
        }

    }

})();