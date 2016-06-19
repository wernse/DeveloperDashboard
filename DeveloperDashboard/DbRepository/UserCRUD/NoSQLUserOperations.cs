using System;
using System.Collections.Generic;
using System.Linq;
using DeveloperDashboard.Models;
using Raven.Client;
using Raven.Client.Document;
using static DeveloperDashboard.DbRepository.NoSQL.NoSQL;


namespace DeveloperDashboard.DbRepository.UserCRUD
{
    public class NoSQLUserOperations : IUserOperations
    {
        public IEnumerable<User> GetAllUsers()
        {
            using (IDocumentSession session = RavenContext.CreateSession())
            {
                IEnumerable<User> userListEnumerable = session.Query<User>().ToList();
                return userListEnumerable;
            }
        }
    }
}