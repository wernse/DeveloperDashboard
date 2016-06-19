using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DeveloperDashboard.Models;
using Raven.Client;
using Raven.Client.Indexes;
using static DeveloperDashboard.DbRepository.NoSQL.NoSQL;

namespace DeveloperDashboard.DbRepository
{
    public class NoSQLScheduleOperations : IScheduleOperations
    {
        public IEnumerable<Schedule> GetAllSchedules(string date)
        {
            using (IDocumentSession session = RavenContext.CreateSession())
            {
                List<Schedule> results = session
                    .Query<Schedule>()
                    .Where(x => x.Date.Equals(date))
                    .ToList();
                return results;
            }
        }

        public IEnumerable<UserReport> GetBillableTotalHours(List<string> dates)
        {
            using (IDocumentSession session = RavenContext.CreateSession())
            {
                new GetBillableTotalHoursIndex().Execute(RavenContext.store);
                //use transformer with parameter? https://ravendb.net/docs/article-page/3.0/csharp/transformers/passing-parameters
                var test = session
                    .Query<GetBillableTotalHoursIndex.Result, GetBillableTotalHoursIndex>().ToList(); ;

                List<UserReport> schedule = session
                    .Query<Schedule, GetBillableTotalHoursIndex>()

                    .Where(x => dates.Contains(x.Date))
                    .Select(x => new UserReport//Map group of schedules by userid create a UserReport
                    {
                        BillableHours =
                             x.Tasks//Map Task in schedule
                            .Where(y => y.Billable)//Return Tasks that are billable
                            .Select(d => d.Hours)//Map task that is billable
                            .DefaultIfEmpty(0)//If null then make 0. Prevents null throw if no billable hours
                            .Sum(),//Sum up all Billable Tasks
                        NonBillableHours =
                             x.Tasks//Map Task in schedule
                            .Where(y => !y.Billable)//Return Tasks that are billable
                            .Select(d => d.Hours)//Map task that is billable
                            .DefaultIfEmpty(0)//If null then make 0. Prevents null throw if no billable hours
                            .Sum()//Sum up all Billable Tasks
                    }
                    )
                    .ToList();
                return schedule;
            }
        }

        public Schedule GetScheduleByUserAndDate(string userId, string date)
        {
            using (IDocumentSession session = RavenContext.CreateSession())
            {
                Schedule schedule = session
                    .Query<Schedule>()
                    .FirstOrDefault(x => x.Date.Equals(date) && x.UserId.Equals(userId));
                return schedule;
            }
        }

        public string SaveSchedule(Schedule schedule)
        {
            using (IDocumentSession session = RavenContext.CreateSession())
            {
                session.Store(schedule);
                session.SaveChanges();
                return "OK";
            }
        }

        public class GetBillableTotalHoursIndex : AbstractIndexCreationTask<Schedule>
        {
            public class Result
            {
                public string UserId { get; set; }

                public string Date{ get; set; }

                public List<Task> Tasks { get; set; }
            }

            public GetBillableTotalHoursIndex()
            {
                Map = schedules => from schedule in schedules
                    select new
                    {
                        UserId = schedule.UserId,
                        Date = schedule.Date,
                        Tasks = schedule.Tasks
                    };

            Reduce = results => from result in results
                    group result by result.UserId
                    into g
                    let taskss = g.Select(x=>x.Tasks)
                    let dates = g.Select(x=>x.Date)
                    select new
                    {
                        UserId = g.Key,
                        Date = dates,
                        Tasks = taskss
                    };
            }
        }
    }
}