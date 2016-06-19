using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DeveloperDashboard.Models;
using System.Collections.Generic;
using System.Diagnostics;

namespace DeveloperDashboard.Tests.Models
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void GetAllUsers()
        {
            User user = new User();
            IEnumerable<User> users = user.GetAllUsers();
            List<User> usersList = new List<User>(users);
            foreach(User userObj in usersList)
            {
                Debug.WriteLine(userObj.Id + ": " + userObj.Name);
            }
            Debug.WriteLine(usersList.Count);
            Assert.IsNotNull(users);
            Assert.AreEqual(usersList.Count, 4);
        }
    }
}
