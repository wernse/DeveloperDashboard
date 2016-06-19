using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DeveloperDashboard.Models;
using DeveloperDashboard.DbRepository.SQL;

namespace DeveloperDashboard.DbRepository
{
    public class SQLScheduleOperations : IScheduleOperations
    {
        /// <summary>
        /// <see cref="GetAllSchedules(string date)"/>uses eager loading
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public IEnumerable<Schedule> GetAllSchedules(string date)
        {
            using (ContextModel db = new ContextModel())
            {
                var item = db.Schedules
                    .Include("Tasks")
                    .Where(x => x.Date == date)
                    .ToList();

                return item;
            }
        }

        /// <summary>
        /// Gets the billable/non-billable hours for a list of dates
        /// </summary>
        /// <param name="dates"></param>
        /// <returns>A List of UserReports that contain userId, billable, non-billable hours</returns>
        public IEnumerable<UserReport> GetBillableTotalHours(List<string> dates)
        {
            using (ContextModel db = new ContextModel())
            {
                //Each select is a list of the schedule's total hours
                var schedules = db.Schedules
                    .Include("Tasks")
                    .Where(x => dates.Contains(x.Date))
                    .GroupBy(x => x.UserId)
                    .Select(x => new UserReport
                    {
                        UserId = x.Key,
                        BillableHours = x.Select(z => z.Tasks//Map Task in schedule
                           .Where(y => y.Billable)//Return Tasks that are billable
                           .Select(d => d.Hours)//Map task that is billable
                           .DefaultIfEmpty(0)//If null then make 0. Prevents null throw if no billable hours
                           .Sum())//Sum up all Billable Tasks
                            .Sum(),//Sum up the group of schedules
                        NonBillableHours = x.Select(c => c.Tasks.Where(d => !d.Billable).Select(d => d.Hours).DefaultIfEmpty(0).Sum()).Sum()
                    }).ToList();
   
                return schedules;
            }
        }

        // public List<UserReport> GetTasks

        /// <summary>
        /// <see cref="GetScheduleByUserAndDate(string userId, string date)"/>uses eager loading
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public Schedule GetScheduleByUserAndDate(string userId, string date)
        {
            using(ContextModel db = new ContextModel())
            {
                var item = db.Schedules
                    .Include("Tasks")
                    .FirstOrDefault(x => x.UserId.Equals(userId)&& x.Date == date);

                 return item;
            }
        }

        /// <summary>
        /// <see cref="SaveSchedule(Schedule schedule)"/>
        /// Clear the Tasks in the task table and change/add new refs
        /// Removes all the tasks schedules and saves the new task given the order it was passed in
        /// </summary>
        /// <param name="schedule"></param>
        /// <returns></returns>
        public String SaveSchedule(Schedule schedule)
        {
            using (ContextModel db = new ContextModel())
            {
                Schedule item = db.Schedules
                    .Include("Tasks")
                    .FirstOrDefault<Schedule>(x => x.UserId == schedule.UserId && x.Date == schedule.Date);
                if (item != null) {
                    db.Tasks.RemoveRange(item.Tasks);
                    for(int i =0; i<schedule.Tasks.Count; i++)
                    {
                        schedule.Tasks[i].TaskId = i.ToString();
                    }
                    db.Schedules.Add(schedule);
                    item.Tasks = schedule.Tasks;
                }
                else
                    db.Schedules.Add(schedule);
                db.SaveChanges();
                return "success";
            }
        }


    }
}