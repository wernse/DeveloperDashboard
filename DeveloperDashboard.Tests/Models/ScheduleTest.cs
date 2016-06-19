using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DeveloperDashboard.Models;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;

namespace DeveloperDashboard.Tests.Models
{
    [TestClass]
    public class ScheduleTest
    {
        private readonly Schedule _schedule = new Schedule();
        [TestMethod]
        public void TestGetAllSchedules()
        {
            // Act
            string inputDate = "2016-06-01";
            List<Schedule> result = _schedule.GetAllSchedules(inputDate).ToList();
            foreach(Schedule scheduleItem in result)
            {
                Debug.WriteLine(scheduleItem.Date);
            }
            // Assert
            Assert.AreEqual(result.First().Date, inputDate);
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void GetBillableTotalHours()
        {
            // Act
            List<string> inputDates = new List<string> { "2016-05-30", "2016-05-31", "2016-06-01", "2016-06-02", "2016-06-03", "2016-06-04", "2016-06-05"};
            List<UserReport> result = _schedule.GetBillableTotalHours(inputDates).ToList();
            Debug.WriteLine(result.Count());
            foreach (UserReport scheduleItem in result)
            {
                Debug.WriteLine("UserId: "+ scheduleItem.UserId + "BillableHours: " + scheduleItem.BillableHours + " nonBillableHours : " + scheduleItem.NonBillableHours);
            }

            List<string> invalidDate = new List<string> { "0000-05-30" };
            IEnumerable<UserReport> invalidResult = _schedule.GetBillableTotalHours(invalidDate);
 
            // Assert
            Assert.IsNotNull(result);

            Assert.IsNotNull(invalidResult);
            Assert.AreEqual(invalidResult.Count(), 0);
        }
    }
}
