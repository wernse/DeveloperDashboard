using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DeveloperDashboard.Models;
using DeveloperDashboard.DbRepository.SQL;

namespace DeveloperDashboard.DbRepository
{
    public class SQLUserOperations : IUserOperations
    {
        /// <summary>
        /// <see cref="IUserOperations.GetAllUsers()"/>
        /// </summary>
        public IEnumerable<User> GetAllUsers()
        {
            using (ContextModel db = new ContextModel())
            {
                var query = from b in db.Users
                            select b;

                return query.ToList();
            }
        }
    }
}