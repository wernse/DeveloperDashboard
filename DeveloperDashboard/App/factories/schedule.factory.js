//Used to store the schedules and do operations
(function () {
    'use strict';
    angular.module('app')
        .factory('scheduleFactory', scheduleFactory);

    function scheduleFactory() {
        var scheduleFactory = {
            setSchedules: setSchedules,
            getSchedules: getSchedules
        };

        return scheduleFactory;

        function setSchedules(schedulesArray) {
            this.schedules = schedulesArray;
        }

        function getSchedules() {
            return this.schedules;
        }

    }
})();