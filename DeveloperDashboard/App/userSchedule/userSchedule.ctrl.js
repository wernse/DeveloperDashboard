(function () {
    'use strict';
    angular
        .module('userSchedule')
        .controller('userScheduleCtrl', [
            '$routeParams',
            '$location',
            '$mdDialog',
            'userScheduleFactory',
            'editTaskFactory',
            'dateFactory',
            userScheduleCtrl
          ]);
  
    //Controller for the user schedule page
    function userScheduleCtrl($routeParams, $location, $mdDialog, userScheduleFactory, editTaskFactory, dateFactory) {
        var ctrl = this;
        ctrl.moveRowUp = moveRowUp;
        ctrl.moveRowDown = moveRowDown;
        ctrl.removeRow = removeRow;
        ctrl.saveSchedule = saveSchedule;
        ctrl.createNewTask = createNewTask;
        ctrl.editTask = editTask;
        ctrl.findSchedule = findSchedule;
        init();

        //Initializes the data for page
        function init() {
            //if there is no user then return back
            if (!angular.isDefined($routeParams.user)) {
                $location.path('/').search({});
            }
            //set date and user
            ctrl.user = $routeParams.user;
            ctrl.date = dateFactory.getDate();
            findSchedule(ctrl.user.Id, ctrl.date);
        };


        //swap with row above
        function moveRowUp(index) {
            userScheduleFactory.swapRows(ctrl.schedule.Tasks, index, index - 1);
        }

        //swap with row below
        function moveRowDown(index) {
            userScheduleFactory.swapRows(ctrl.schedule.Tasks, index, index + 1);
        }

        //remove row
        function removeRow(index) {
            userScheduleFactory.removeRow(ctrl.schedule.Tasks, index);
        }
  
        //saves the current schedule
        function saveSchedule(schedule) {
            userScheduleFactory.saveSchedule(schedule)
               .then(data => {
                   console.log("saved schedule", data);
                    $location.path('/').search({});
               }).catch(error => {
                   console.error("error", error);
               });
        }

        //insert a new task into the schedule
        function createNewTask(schedule) {
            if (angular.isUndefined(schedule.Tasks))
                schedule.Tasks = {};
            else
                schedule.Tasks.push({});
            console.log(schedule);
        }

        //triggers when a user is clicked
        function editTask(ev, tasks,index) {
            editTaskFactory.setTask(tasks[index]);
            $mdDialog.show({
                controller: 'modalCtrl',
                controllerAs: 'modal',
                templateUrl: 'App/UserSchedule/partials/modal.html',
                targetEvent: ev,
                clickOutsideToClose: true
            })
            .then(savedTask => {
                //if task is saved then set new task
                    tasks[index] = savedTask;
            });
        }

        //find a schedule based on user and date
        function findSchedule(userId, date) {
            dateFactory.setDate(date);
            userScheduleFactory.findSchedule(userId, date)
               .then(data => {
                   console.log("found schedule", data);
                   ctrl.schedule = data;
               }).catch(error => {
                   ctrl.schedule = data;
                   console.error("error", error);
               });
        }

        return ctrl;
    }
})();