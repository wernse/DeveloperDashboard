(function () {
    'use strict';
    angular.module('userSchedule')
        .factory('userScheduleFactory', [
            'httpFactory',
            'dateFactory',
            userScheduleFactory
        ]);

    function userScheduleFactory(httpFactory, dateFactory) {
        var userScheduleFactory = {
            swapRows: swapRows,
            removeRow: removeRow,
            saveSchedule: saveSchedule,
            findSchedule: findSchedule
        };

        return userScheduleFactory;

        //sets the user from the modal
        function swapRows(array, from, to) {
            console.log(array, from, to);
            var tmp = array[from];
            array[from] = array[to];
            array[to] = tmp;
        };

        //remove row from array
        function removeRow(array, index) {
            array.splice(index, 1);
        }

        //finds a specific schedule when in the user panel
        function findSchedule(userId, date) {
            date = dateFactory.formatDate(date);
            var formData = {
                'UserId': userId,
                'Date': date
            }
            var postData = JSON.stringify(formData);
            var settings = {
                method: 'POST',
                url: 'Schedule/GetScheduleByUserAndDate',
                data: postData,
                headers: { 'Content-Type': 'application/json' }
            }
            return httpFactory.post(settings);
        }

        //saves the schedule after user has worked on it
        function saveSchedule(schedule) {
            var postData = JSON.stringify(schedule);
            var settings = {
                method: 'POST',
                url: 'Schedule/SaveSchedule',
                data: postData,
                headers: { 'Content-Type': 'application/json' }
            }
            return httpFactory.post(settings);
        }
    }
})();