(function () {
    'use strict';
    angular.module('userSchedule')
        .factory('editTaskFactory',
            editTaskFactory
        );
    
    function editTaskFactory() {
        var editTaskFactory = {
            setTask: setTask,
            getTask: getTask
        };

        function setTask(task) {
            console.log(task);
            this.task = task;
        };

        function getTask(task) {
            return this.task;
        };

        return editTaskFactory;
        }

})();