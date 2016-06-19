(function () {
    'use strict';
    angular.module('dashboard')
        .controller('dashboardCtrl',
        [
            '$location',
            'dateFactory',
            'dashboardFactory',
            'userFactory',
            'companyFactory',
            dashboardCtrl
        ]);

    //Landing Controller for the initial page
    function dashboardCtrl($location, dateFactory, dashboardFactory, userFactory, companyFactory) {
        var ctrl = this;
        ctrl.findScheduleById = findScheduleById;
        ctrl.lookAtSchedule = lookAtSchedule;
        ctrl.findAllSchedules = findAllSchedules;
        init();
        
  


        //Initializes the data for page
        function init() {
            initDate();
            getCompanies();
            getUsers();
            findAllSchedules(ctrl.date);

            function initDate() {
                if (angular.isUndefined(dateFactory.getDate()))
                    dateFactory.setDate(new Date());
                ctrl.date = dateFactory.getDate();
            }
        };

        //finds the username given the id
        function findScheduleById(id) {
            if(angular.isDefined(ctrl.schedules)){
                return dashboardFactory.findScheduleByUser(id,ctrl.schedules);
            }
        }

        function lookAtSchedule(user) {
            $location.path('/userSchedule').search({ 'user': user });
        }

        //Gets the data and stores in ctrl.companies
        function getCompanies() {
            dashboardFactory.getCompanies()
               .then(function (data) {
                   ctrl.companies = data;
                   companyFactory.setCompanies(ctrl.companies);
                   companyFactory.createCompanyMap(ctrl.companies);
               }).catch(function (error) {
                   console.error("error", error);
               });
        }
        //gets all users
        function getUsers() {
            dashboardFactory.getUsers()
               .then(function (data) {
                   ctrl.users = data;
                   userFactory.setUsers(data);
                   userFactory.createUserMap(data);
               }).catch(function (error) {
                   console.error("error", error);
               });
        }

        //returns all the schedules for init dashboard and date changes
        function findAllSchedules(date) {
            dateFactory.setDate(date);
            dashboardFactory.findAllSchedules(date)
               .then(function (data) {
                    console.log("findAllSchedules", data);
                   ctrl.schedules = data;
               }).catch(function (error) {
                   console.error("error", error);
               });
        }

        return ctrl;
    }
})();