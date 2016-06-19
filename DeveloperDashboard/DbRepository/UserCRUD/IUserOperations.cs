using DeveloperDashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperDashboard.DbRepository { 
    interface IUserOperations
    {
        /// <summary>
        /// Gets all users in storage
        /// </summary>
        /// <returns>A List of users</returns>
        IEnumerable<User> GetAllUsers();
    }
}
