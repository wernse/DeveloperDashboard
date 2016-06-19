//Used to create maps from the requests
//Need it to get colours/names from ids since we dont want to join them into one single list
(function () {
    'use strict';
    angular.module('date', []);

    angular.module('date')
        .factory('dateFactory', dateFactory);

    function dateFactory() {
        var dateFactory = {
            getDate: getDate,
            setDate: setDate,
            formatDate : formatDate,
            getDateRange: getDateRange
        };

        return dateFactory;

        function getDate() {
            return this.date;
        }
        function setDate(date) {
            this.date = date;
        }

        //need to add 12 hours as new Date() is GMT +12 and date.toJson does not include the +12 GMT
        //Slice to only get only the time
        function formatDate(date) {
            date = new Date(date.getTime() + (12 * 60 * 60 * 1000));
            return date.toJSON().slice(0, 10);
        }

        //gets the monday and sunday dates based on input date
        //dates = { monday: 27,sunday: 33}
        function getDateRange(d) {
            var currentDate = new Date(d);

            //get the current day 0-6
            var day = currentDate.getDay();

            //d.getDate gets the date of the month - the current day index e.g. sunday = 0, mon = 1, tuesday = 2
            //subtract current day(to get to start of week) sunday
            var startSundayDate = currentDate.getDate() - day;

            //then add 1 to get to monday else if its sunday go back to prev monday
            var monday = startSundayDate + (day === 0 ? -6 : 1); // adjust when day is sunday

            //add 6 days to monday will be sunday
            var sunday = monday + 6;
            var dateArray = createDateArray(currentDate, monday, sunday);
            return dateArray;
        }

        //date,-1, 5
        //create a date array ['2016-05-30', '2016-05-31', '2016-06-01', '2016-06-02', '2016-06-03', '2016-06-04', '2016-06-05']
        function createDateArray(selectedDate, monday, sunday) {
            var dateList = [];
            for (var day = monday; day < sunday+1; day++) {
                var dateClone = angular.copy(selectedDate);
                var date = new Date(dateClone.setDate(day));
                var formattedDate = date.toJSON().slice(0, 10);
                dateList.push(formattedDate);
            }
            console.log(dateList);
            return dateList;
        }
        
    }
})();