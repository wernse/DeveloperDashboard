(function () {
    'use strict';
    angular
        .module('userSchedule')
        .controller('modalCtrl', [
            '$mdDialog',
            'editTaskFactory',
            'companyFactory',
            modalCtrl
        ]);

    //Controller for the user schedule page
    function modalCtrl($mdDialog, editTaskFactory, companyFactory) {
        var ctrl = this;
        ctrl.cancel = cancel;
        ctrl.save = save;
        ctrl.companyMap = companyFactory.companyMap;
        //used to prevent eager saving to the refed obj, requires a confirm button before saving
        var task = editTaskFactory.getTask();
        ctrl.task = angular.copy(task);

        //cancles the modified task
        function cancel() {
            $mdDialog.cancel();
        };

        //saves the modified task
        function save (task) {
            $mdDialog.hide(task);
        };

        return ctrl;
    }
})();