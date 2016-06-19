(function () {
    'use strict';
    angular.module('dashboard')
        .factory('dashboardFactory', [
            'httpFactory',
            'dateFactory',
            dashboardFactory
        ]);

    function dashboardFactory(httpFactory, dateFactory) {
        var dashboardFactory = {
            getCompanies: getCompanies,
            getUsers: getUsers,
            findScheduleByUser : findScheduleByUser,
            findAllSchedules: findAllSchedules,
        };

        return dashboardFactory;


        //gets the list of companies in db for colour coding
        function getCompanies() {
            console.log("Company/GetAllCompanies");
            return httpFactory.get("Company/GetAllCompanies");
        }

        //gets the list of users 
        function getUsers() {
            console.log("Company/GetAllCompanies");
            return httpFactory.get("User/GetAllUsers");
        }

        //finds a schedule from schedules given userId
        function findScheduleByUser(id, schedules) {
            var returnSchedule;
            schedules.some(schedule => {
                if (schedule.UserId === id) {
                    returnSchedule = schedule;
                    return true;
                }
            });
            return returnSchedule;
        }

        //returns all the schedules for init dashboard and date changes
        function findAllSchedules(date) {
            date = dateFactory.formatDate(date);
            console.log(date);
            var formData = {
                'Date': date
            }
            var postData = JSON.stringify(formData);
            var settings = {
                method: 'POST',
                url: 'Schedule/GetAllSchedules',
                data: postData,
                headers: { 'Content-Type': 'application/json' },
            }
            return httpFactory.post(settings);
        }



    }
})();