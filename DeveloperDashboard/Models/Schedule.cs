using DeveloperDashboard.DbRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeveloperDashboard.Models
{
    public class Schedule
    {
        private readonly IScheduleOperations _scheduleOperations = new NoSQLScheduleOperations();

        public string Id { get; set; }
        public string UserId { get; set; }
        public string Date { get; set; }
        public List<Task> Tasks { get; set; }

        /// <summary>
        /// Gets all schedules for a given date list
        /// </summary>
        /// <param name="dates"></param>
        /// <returns>An IEnumerable of all schedules in date list</returns>
        public IEnumerable<UserReport> GetBillableTotalHours(List<string> dates)
        {
            return _scheduleOperations.GetBillableTotalHours(dates);
        }

        /// <summary>
        /// Returns all schedules on a certain date
        /// </summary>
        /// <param name="date"></param>
        /// <returns>An IEnumerable of all schedules</returns>
        public IEnumerable<Schedule> GetAllSchedules(String date)
        {
            return _scheduleOperations.GetAllSchedules(date);
        }

        /// <summary>
        /// Gets a schedule by user and date
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="Date"></param>
        /// <returns>A schedule</returns>
        public Schedule GetScheduleByUserAndDate(String userId, String date)
        {
            Schedule foundSchedule = _scheduleOperations.GetScheduleByUserAndDate(userId, date);

            //if null then create a schedule and return it, for creating new task lists
            if (foundSchedule == null)
                return new Schedule { UserId = userId, Date = date, Tasks = new List<Task>()};
            return foundSchedule;
        } 
        /// <summary>
        /// Saves a schedule to storage
        /// </summary>
        /// <param name="schedule"></param>
        /// <returns></returns>
        public String SaveSchedule(Schedule schedule)
        {
            return _scheduleOperations.SaveSchedule(schedule);
        }
    }
}