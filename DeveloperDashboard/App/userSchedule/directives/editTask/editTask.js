//Component to edit the task
//Since this uses a factory instead of a one way binding, the referenced obj is always changed
(function () {
    'use strict';
    angular
        .module('userSchedule')
        .component('editTask', {
            templateUrl: '/App/userSchedule/directives/editTask/editTask.html',
            controller: ['companyFactory', editTaskCtrl],
            bindings: {
                task : '<'
            }
        });

    //Controller for each individual task
    function editTaskCtrl(companyFactory) {
        var ctrl = this;

        ctrl.changeCompany = changeCompany;
        init();

        function init() {
            ctrl.companies = companyFactory.getCompanies();
        }

        function changeCompany(company, task) {
            console.log(company, task);
        }

        return ctrl;
    }
})();