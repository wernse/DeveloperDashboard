using DeveloperDashboard.Models;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Indexes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using DeveloperDashboard.App_Start;

namespace DeveloperDashboard.DbRepository.NoSQL
{
    public class NoSQL
    {


        public void SaveObject<T>(T objectToSave)
        {
            using (IDocumentSession session = RavenConfig.Store.OpenSession())
            {
                session.Store(objectToSave); // stores employee in session, assigning it to a collection `Employees`
                session.SaveChanges();
            }
        }



        public List<T> GetAllObjects<T>()
        {
            using (IDocumentSession session = RavenConfig.Store.OpenSession())
            {
                List<T> objectList = session.Query<T>()
                    .ToList();
                return objectList;
            }
        }

        public void DeleteAll<T>()
        {
            using (IDocumentSession session = RavenConfig.Store.OpenSession())
            {

                List<T> userList = session.Query<T>()
                    .ToList();

                foreach (T userToBeDelected in userList)
                {
                    session.Delete(userToBeDelected);
                    session.SaveChanges();
                }
            }
        }

        public void InitSchedules()
        {
            using (IDocumentSession session = RavenConfig.Store.OpenSession())
            {
                session.Store(
                    new Schedule
                    {
                        UserId = "users/292",
                        Date = "2016-06-01",
                        Tasks = new List<Task>
                        {
                            new Task
                            {
                                CompanyId = "companies/33",
                                Description = "Research Azure Options",
                                Status = "Planning",
                                Billable = true,
                                Meta = "Requested by Mr Smith",
                                Hours = 5
                            },
                            new Task
                            {
                                CompanyId = "companies/33",
                                Description = "Meeting with Mr Smith",
                                Status = "Planning",
                                Billable = false,
                                Meta = "About Azure costing",
                                Hours = 10
                            },
                            new Task
                            {
                                CompanyId = "companies/34",
                                Description = "Create dashboard feature",
                                Status = "Developing",
                                Billable = true,
                                Meta = "Metrics for business sales",
                                Hours = 3
                            },
                        }
                    });
                session.SaveChanges();
            }
        }

        public void InitStore()
        {
            DeleteAll<User>();
            DeleteAll<Company>();
            DeleteAll<Schedule>();
            using (IDocumentSession session = RavenConfig.Store.OpenSession())
            {
                session.Store(new User
                {
                    Name = "Alan",
                });
                session.Store(new User
                {
                    Name = "Christopher",
                });
                session.Store(new User
                {
                    Name = "Arthur",
                });
                session.Store(new User
                {
                    Name = "Daniel",
                });
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
        public class AllUsers : AbstractIndexCreationTask<User>
        {
            public class Result
            {
                public string UserId { get; set; }

                public string Company { get; set; }

                public decimal Total { get; set; }
            }

            //public AllUsers()
            //{
            //    Map = users => from user in users
            //                    select new
            //                    {
            //                        user.Employee,
            //                        order.Company,
            //                        Total = order.Lines.Sum(l => (l.Quantity * l.PricePerUnit) * (1 - l.Discount))
            //                    };
            //}
        }
    }
}