angular.module("templates", []).run(["$templateCache", function($templateCache) {$templateCache.put("dashboard/dashboard.html","<navbar></navbar>\r\n<div>\r\n    <div class=\"container\">\r\n        <section>\r\n            <h4>Standard date-picker</h4>\r\n            <md-datepicker ng-model=\"dashboard.date\" md-placeholder=\"Enter date\" ng-change=\"dashboard.findAllSchedules(dashboard.date)\"></md-datepicker>\r\n        </section>\r\n        <section>\r\n            <h4>Schedules</h4>\r\n            <div layout=\"row\" layout-xs=\"column\">\r\n                <div class=\"col-md-3\" ng-repeat=\"user in dashboard.users\">\r\n                    <task-container ng-click=\"dashboard.lookAtSchedule(user)\" header-display=\"user.Name\" task-data=\"dashboard.findScheduleById(user.Id)\"></task-container>\r\n                </div>\r\n            </div>\r\n        </section>\r\n    </div>\r\n</div>");
$templateCache.put("report/report.html","<navbar></navbar>\r\n<div>\r\n    <div class=\"container\">\r\n        <section>\r\n            <h4>Standard date-picker</h4>\r\n            <md-datepicker ng-model=\"report.date\" md-placeholder=\"Enter date\" ng-change=\"report.getWeeklySchedulesByDate(report.date)\"></md-datepicker>\r\n        </section>\r\n        <section>\r\n            <md-toolbar class=\"md-theme-light\">\r\n                <h2 class=\"md-toolbar-tools\">\r\n                    <span>Developer Hours: {{report.dateRange[0]}} to {{report.dateRange[report.dateRange.length-1]}}</span>\r\n                </h2>\r\n            </md-toolbar>\r\n            <md-content>\r\n                <md-list>\r\n                    <md-list-item class=\"md-3-line\" ng-repeat=\"hours in report.taskHours\">\r\n                        <div class=\"md-list-item-text\">\r\n                            <h3><b>{{report.userMap[hours.UserId]}}</b>:  {{hours.BillableHours/(hours.NonBillableHours+hours.BillableHours)*100|number:2}}%</h3>\r\n                            <h4>Billable : {{hours.BillableHours}}h</h4>\r\n                            <h4>Non-Billable : {{hours.NonBillableHours}}h</h4>\r\n                            <md-divider ng-if=\"!$last\"></md-divider>\r\n                        </div>\r\n                        <md-button class=\"md-secondary\">Details</md-button>\r\n                    </md-list-item>\r\n                </md-list>\r\n            </md-content>\r\n        </section>\r\n    </div>\r\n</div>");
$templateCache.put("userSchedule/userSchedule.html","<navbar></navbar>\r\n<div class=\"container\">\r\n    <section>\r\n        <h4>Standard date-picker</h4>\r\n        <md-datepicker ng-model=\"user.date\" md-placeholder=\"Enter date\" ng-change=\"user.findSchedule(user.user.Id, user.date)\"></md-datepicker>\r\n        <md-button class=\"float-right md-raised\" ng-click=\"user.createNewTask(user.schedule)\">Add Row</md-button>\r\n        <md-button class=\"float-right md-raised\" ng-click=\"user.saveSchedule(user.schedule)\">Save Schedule</md-button>\r\n        <div style=\"clear:both\"></div>\r\n    </section>\r\n    <section>\r\n        <md-content class=\"listContainer\">\r\n            <md-toolbar md-scroll-shrink ng-if=\"true\">\r\n                <div class=\"md-toolbar-tools\">\r\n                    <h3>\r\n                        <span>{{user.user.Name}}</span>\r\n                    </h3>\r\n                </div>\r\n            </md-toolbar>\r\n            <md-list>\r\n                <md-list-item ng-repeat=\"task in user.schedule.Tasks\" class=\"md-3-line\">\r\n                    <task-box data=\"task\" flex =\"85\" ng-click=\"user.editTask($event,user.schedule.Tasks,$index)\" ></task-box>\r\n                    <div flex=\"5\" >\r\n                        <md-icon ng-if=\"!$first\" md-menu-align-target ng-click=\"user.moveRowUp($index)\"><i class=\"material-icons\">arrow_upward</i></md-icon>\r\n                        <md-icon ng-if=\"!$last\" md-menu-align-target ng-click=\"user.moveRowDown($index)\"><i class=\"material-icons\">arrow_downward</i></md-icon>\r\n                    </div>\r\n                        <div flex=\"5\" hide-xs hide-sm>\r\n                        <!-- Spacer //-->\r\n                        </div>\r\n                    <div flex=\"5\">\r\n                        <md-icon md-menu-align-target ng-click=\"user.removeRow($index)\"><i class=\"material-icons\">clear</i></md-icon>\r\n                    </div>\r\n                    <md-divider ng-if=\"!$last\"></md-divider>\r\n                </md-list-item>\r\n            </md-list>\r\n        </md-content>\r\n    </section>\r\n</div>");
$templateCache.put("directives/navbar/navbar.html","<div>\r\n    <nav class=\"navbar navbar-inverse fg-default\" role=\"navigation\">\r\n        <div class=\"navbar-header\">\r\n            <button type=\"button\" class=\"navbar-toggle\" data-toggle=\"collapse\" data-target=\"#navbar-collapse-01\">\r\n                <span class=\"sr-only\">Toggle navigation</span>\r\n            </button>\r\n            <div class=\"navbar-header\">\r\n                <span><a href=\"/\" class=\"logo\">Developer Dashboard</a></span>\r\n            </div>\r\n            <ul class=\"nav navbar-nav\">\r\n                <li><a href=\"/\">Dashboard</a></li>\r\n                <li><a href=\"/report\">Report</a></li>\r\n            </ul>\r\n        </div>\r\n    </nav>\r\n</div>");
$templateCache.put("directives/task/task.html","<div class=\"taskItemContainer\">\r\n    <div class=\"md-list-item-text tile {{$ctrl.colour}}\" >\r\n        <div flex-xs flex=\"\" layout-gt-xs=\"row\" layout-align=\"center center\">\r\n            <div flex=\"50\">\r\n                <i class=\"material-icons\">\r\n                    <span ng-if=\"!$ctrl.data.Billable\">money_off</span>\r\n                    <span ng-if=\"$ctrl.data.Billable\">attach_money</span>\r\n                </i>\r\n            </div>\r\n            <div flex=\"50\" class=\"text-right\">\r\n                <i class=\"material-icons\">alarm</i>{{$ctrl.data.Hours}}\r\n            </div>\r\n        </div>\r\n \r\n        <h3>{{$ctrl.data.Status}}</h3>\r\n        <p>{{$ctrl.data.Description}}</p>\r\n    </div>\r\n</div>");
$templateCache.put("directives/taskContainer/taskContainer.html","<div class=\"taskContainer\" >\r\n    <md-content>\r\n        <md-toolbar md-scroll-shrink ng-if=\"true\">\r\n            <div class=\"md-toolbar-tools\">\r\n                <h3>\r\n                    <span>{{$ctrl.headerDisplay}}</span>\r\n                </h3>\r\n            </div>\r\n        </md-toolbar>\r\n        <md-list flex=\"\">\r\n            <md-list-item ng-repeat=\"task in $ctrl.taskData.Tasks\" class=\"md-3-line\">\r\n                <task-box data=\"task\" flex=\"100\"></task-box>\r\n                <md-divider ng-if=\"!$last\"></md-divider>\r\n            </md-list-item>\r\n        </md-list>\r\n    </md-content>\r\n</div>\r\n");
$templateCache.put("userSchedule/partials/modal.html","<edit-task aria-label=\"User Schedule popup\" task=\"modal.task\"></edit-task>\r\n<md-dialog-actions layout=\"row\">\r\n    <md-button ng-click=\"modal.cancel()\">Cancel</md-button>\r\n    <md-button ng-click=\"modal.save(modal.task)\" style=\"margin-right:20px;\">Save</md-button>\r\n</md-dialog-actions>");
$templateCache.put("userSchedule/directives/editTask/editTask.html","<md-content layout-padding=\"\" flex-gt-sm=\"\">\r\n    <div>\r\n        <div layout-gt-xs=\"row\" >\r\n            <md-input-container class=\"md-block\" flex-gt-sm=\"\">\r\n                <label>Status</label>\r\n                <input ng-model=\"$ctrl.task.Status\">\r\n            </md-input-container>\r\n            <div flex=\"5\" hide-xs hide-sm>\r\n                <!-- Spacer //-->\r\n            </div>\r\n            <div flex-xs flex=\"40\" layout-gt-xs=\"row\" layout-align=\"center center\">\r\n                <div flex-xs flex=\"50\">\r\n                    <md-input-container class=\"md-block\" flex-gt-sm=\"\">\r\n                        <label>Hours</label>\r\n                        <input ng-model=\"$ctrl.task.Hours\">\r\n                    </md-input-container>\r\n                </div>\r\n                <div flex=\"5\" hide-xs hide-sm>\r\n                    <!-- Spacer //-->\r\n                </div>\r\n                <div flex-xs flex=\"50\">\r\n                    <md-checkbox ng-model=\"$ctrl.task.Billable\" aria-label=\"Checkbox 1\">Billable</md-checkbox>\r\n                </div>\r\n              \r\n            </div>\r\n        </div>\r\n\r\n        <div layout-gt-xs=\"row\">\r\n            <md-input-container class=\"md-block\" flex-gt-xs=\"\">\r\n                <label>Description</label>\r\n                <input ng-model=\"$ctrl.task.Description\">\r\n            </md-input-container>\r\n        </div>\r\n\r\n        <div layout-gt-xs=\"row\">\r\n            <md-input-container class=\"md-block\" flex-gt-sm=\"\">\r\n                <label>Company</label>\r\n                <md-select ng-model=\"$ctrl.task.CompanyId\" ng-change=\"$ctrl.changeCompany($ctrl.task.CompanyId, $ctrl.task)\">\r\n                    <md-option ng-repeat=\"company in $ctrl.companies\" value=\"{{company.Id}}\">\r\n                        {{company.Name}}\r\n                    </md-option>\r\n                </md-select>\r\n            </md-input-container>\r\n        </div>\r\n        <div layout-gt-xs=\"row\">\r\n            <md-input-container class=\"md-block\" flex-gt-sm=\"\">\r\n                <label>Meta</label>\r\n                <input ng-model=\"$ctrl.task.Meta\">\r\n            </md-input-container>\r\n        </div>\r\n    </div>\r\n</md-content>\r\n");}]);