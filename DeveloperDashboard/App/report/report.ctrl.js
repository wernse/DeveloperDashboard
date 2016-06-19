(function () {
    'use strict';

    angular
        .module('app')
        .controller('reportCtrl', [
            'reportFactory',
            'dateFactory',
            reportCtrl]);

    function reportCtrl(reportFactory, dateFactory) {
        var ctrl = this;
        ctrl.getWeeklySchedulesByDate = getWeeklySchedulesByDate;

        init();
        function init() {
            ctrl.date = dateFactory.getDate();
            ctrl.userMap = reportFactory.getUserMap();
            console.log(ctrl.userMap)
            getWeeklySchedulesByDate(ctrl.date);
        }

        //takes a date input then finds the week dates and gets all schedules
        function getWeeklySchedulesByDate(date) {
            ctrl.dateRange = dateFactory.getDateRange(date);
            reportFactory.GetAllSchedulesForGivenDates(ctrl.dateRange)
                .then(data => {
                    ctrl.taskHours = data;
                    console.log(data);
                })
                .catch(error => {
                    console.error(error);
                });
        }
    }
})();
