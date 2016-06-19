(function () {
    'use strict';

    angular
        .module('app')
        .factory('reportFactory', [
            'httpFactory',
            'userFactory',
            reportFactory]);

    function reportFactory(httpFactory, userFactory) {
        var reportFactory = {
            GetAllSchedulesForGivenDates: GetAllSchedulesForGivenDates,
            getUserMap: getUserMap
        };

        //Gets the schedules for the entire week
        function GetAllSchedulesForGivenDates(dates) {
            var formData = {
                'dates': dates,
            }
            var postData = JSON.stringify(formData);
            var settings = {
                method: 'POST',
                url: 'Schedule/GetReport',
                data: postData,
                headers: { 'Content-Type': 'application/json' },
            }
            return httpFactory.post(settings);
        }

        function getUserMap() {
            return userFactory.userMap;
        }

        return reportFactory;

    }
})();