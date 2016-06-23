using System;
using System.Collections.Generic;
using System.Diagnostics;
using DeveloperDashboard.App_Start;
using DeveloperDashboard.Controllers;
using DeveloperDashboard.DbRepository.NoSQL;
using DeveloperDashboard.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Raven.Client;

namespace DeveloperDashboard.Tests.DbRepository
{
    [TestClass]
    public class NoSQLTest
    {
        [TestInitialize]
        public void init()
        {
            RavenConfig.Register();
        }
        [TestMethod]
        public void GetAllObjects()
        {
            NoSQL nosql = new NoSQL();
            CreateTestData();
            List<Company> asd = nosql.GetAllObjects<Company>();

            foreach (var company in asd)
            {
                Debug.WriteLine(company.Name);

            }
        }

        private void CreateTestData()
        {
            using (IDocumentSession session = RavenConfig.Store.OpenSession())
            {
                session.Store(new Company
                {
                    Name = "Microsoft",
                    Colour = "blue"
                });
                session.Store(new Company
                {
                    Name = "Walmart",
                    Colour = "red"
                });
                session.Store(new Company
                {
                    Name = "Samsung",
                    Colour = "green"
                });
                session.Store(new Company
                {
                    Name = "Apples",
                    Colour = "white"
                });
                session.SaveChanges();
            }
        }
    }
}
