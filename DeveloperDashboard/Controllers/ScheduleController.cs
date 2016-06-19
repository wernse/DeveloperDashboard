using DeveloperDashboard.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DeveloperDashboard.Controllers
{
    [RoutePrefix("Schedule")]
    public class ScheduleController : ApiController
    {
        private readonly Schedule _schedule = new Schedule();

        [Route("GetReport")]
        [HttpPost]
        public IHttpActionResult GetReport([FromBody]dynamic body)
        {
            List<string> dates = body.dates.ToObject<List<string>>();
            IEnumerable<UserReport> foundSchedules = _schedule.GetBillableTotalHours(dates);
            return Ok(foundSchedules);
        }

        /// <summary>
        /// Gets the initial dashboard for a given day
        /// </summary>
        /// <param name="body">String Date</param>
        /// <returns></returns>
        [Route("GetAllSchedules")]
        [HttpPost]
        public IHttpActionResult GetAllSchedules([FromBody]dynamic body)
        {
            String date = body.Date.Value;
            IEnumerable<Schedule> foundSchedule = _schedule.GetAllSchedules(date);
            if (foundSchedule == null)
                return Content(HttpStatusCode.NotFound, "Foo does not exist.");

            return Ok(foundSchedule);
        }

        /// <summary>
        /// Gets schedule for a specific user and date, For user onclick
        /// </summary>
        /// <param name="body">Int32 UserId, String Date</param>
        /// <returns></returns>
        [Route("GetScheduleByUserAndDate")]
        [HttpPost]
        public IHttpActionResult GetScheduleByUserAndDate([FromBody]dynamic body)
        {
            String userId = body.UserId.Value;
            String date = body.Date.Value;
            Schedule foundSchedule = _schedule.GetScheduleByUserAndDate(userId, date);
            //if schedule is not found
            if(foundSchedule == null) { 
                return Content(HttpStatusCode.NotFound, "Foo does not exist.");
            }
            return Ok(foundSchedule);
        }

        [Route("SaveSchedule")]
        [HttpPost]
        public IHttpActionResult SaveSchedule(Schedule savingSchedule)
        {
            String foundSchedule = _schedule.SaveSchedule(savingSchedule);

            return Ok();
        }
    }
}
