//Used to store and create users
(function () {
    'use strict';
    angular.module('app')
        .factory('userFactory', userFactory);

    function userFactory() {
        var userFactory = {
            setUsers : setUsers,
            getUsers : getUsers,
            createUserMap: createUserMap,
        };

        return userFactory;

        function setUsers(users) {
            this.users = users;
        }

        function getUsers() {
            return this.users;
        }

        //creates a company map so lists can quickly find the color the company id is
        function createUserMap(usersArray) {
            var userMap = {}
            usersArray.forEach(function (user) {
                userMap[user.Id] = user.Name;
            });
            this.userMap = userMap;
        }

    }
})();