using DeveloperDashboard.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DeveloperDashboard.DbRepository.SQL
{
    public class InitializeDashboardSeedData : DropCreateDatabaseAlways<ContextModel>
    {
        //protected override void Seed(ContextModel context)
        //{
        //    base.Seed(context);
        //    context.Companies.Add(new Company
        //    {
        //        Id = 1,
        //        Name = "Microsoft",
        //        Colour = "blue"
        //    });
        //    context.Companies.Add(new Company
        //    {
        //        Id = 2,
        //        Name = "Walmart",
        //        Colour = "red"
        //    });
        //    context.Companies.Add(new Company
        //    {
        //        Id = 3,
        //        Name = "Samsung",
        //        Colour = "green"
        //    });
        //    context.Companies.Add(new Company
        //    {
        //        Id = 4,
        //        Name = "Apples",
        //        Colour = "white"
        //    });

        //    context.Users.Add(new User
        //    {
        //        Id = 1,
        //        Name = "Alan",
        //    });
        //    context.Users.Add(new User
        //    {
        //        Id = 2,
        //        Name = "Christopher",
        //    });
        //    context.Users.Add(new User
        //    {
        //        Id = 3,
        //        Name = "Arthur",
        //    });
        //    context.Users.Add(new User
        //    {
        //        Id = 7,
        //        Name = "Daniel",
        //    });

        //    context.Schedules.Add(new Schedule
        //    {
        //        UserId = 1,
        //        Date = "2016-06-01",
        //        Tasks = new List<Task>
        //        {
        //            new Task
        //            {
        //                CompanyId = 1,
        //                Description = "Research Azure Options",
        //                Status = "Planning",
        //                Billable = true,
        //                Meta = "Requested by Mr Smith",
        //                Hours = 5
        //            },
        //            new Task
        //            {
        //                CompanyId = 1,
        //                Description = "Meeting with Mr Smith",
        //                Status = "Planning",
        //                Billable = false,
        //                Meta = "About Azure costing",
        //                Hours = 10
        //            },
        //            new Task
        //            {
        //                CompanyId = 2,
        //                Description = "Create dashboard feature",
        //                Status = "Developing",
        //                Billable = true,
        //                Meta = "Metrics for business sales",
        //                Hours = 3
        //            },
        //        }
        //    });
        //    context.Schedules.Add(new Schedule
        //    {
        //        UserId = 1,
        //        Date = "2016-06-02",
        //        Tasks = new List<Task>
        //        {
        //            new Task
        //            {
        //                CompanyId = 1,
        //                Description = "Setup Azure VM",
        //                Status = "Developing",
        //                Billable = true,
        //                Meta = "Mr Smith approved Azure hosting",
        //                Hours = 6
        //            },
        //        },
        //    });
        //    context.Schedules.Add(new Schedule
        //    {
        //        UserId = 2,
        //        Date = "2016-06-02",
        //        Tasks = new List<Task>
        //        {
        //            new Task
        //            {
        //                CompanyId = 2,
        //                Description = "Test 2",
        //                Status = "Test 2",
        //                Billable = true,
        //                Meta = "Test 2",
        //                Hours = 7
        //            },
        //        },
        //    });
        //    context.Schedules.Add(new Schedule
        //    {
        //        UserId = 3,
        //        Date = "2016-06-02",
        //        Tasks = new List<Task>
        //        {
        //            new Task
        //            {
        //                CompanyId = 3,
        //                Description = "Test 3",
        //                Status = "Test 3",
        //                Billable = true,
        //                Meta = "Test 3",
        //                Hours = 10
        //            },
        //        },
        //    });
        //    context.SaveChanges();
        //}
    }
}