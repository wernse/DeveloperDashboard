using DeveloperDashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperDashboard.DbRepository
{
    interface IScheduleOperations
    {
        /// <summary>
        /// Gets all the schedules for a list of dates
        /// </summary>
        /// <param name="dates"></param>
        /// <returns>an IEnumerable with all the shedules</returns>
        IEnumerable<UserReport> GetBillableTotalHours(List<string> dates);

        /// <summary>
        /// Gets all the schedules for a specific date
        /// </summary>
        /// <param name="date">"yyyy-mm-dd</param>
        /// <returns></returns>
        IEnumerable<Schedule> GetAllSchedules(String date);

        /// <summary>
        /// Gets a Schedule for a specific user on a specified date
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="date"></param>
        /// <returns>A Schedule</returns>
 
        Schedule GetScheduleByUserAndDate(string userId, String date);
        /// <summary>
        /// Updates the tasks within a schedule
        /// </summary>
        /// <param name="schedule"></param>
        /// <returns></returns>
        String SaveSchedule(Schedule schedule);
    }
}
