using DeveloperDashboard.DbRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DeveloperDashboard.DbRepository.UserCRUD;

namespace DeveloperDashboard.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// Gets all users from Storage
        /// </summary>
        /// <returns>IEnumerable<User></returns>
        public IEnumerable<User> GetAllUsers()
        {
            //IUserOperations userOperations = new SQLUserOperations();
            IUserOperations userOperations = new NoSQLUserOperations();
            IEnumerable<User> users = userOperations.GetAllUsers();
            return users;
        }
    }
}