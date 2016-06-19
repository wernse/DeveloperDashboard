using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DeveloperDashboard.Models
{
    public class Task
    {
        /// <summary>
        /// TaskId for when there are multiple tasks in sql
        /// In noSQL we would abstract the task out and place it in its own table(normalization)
        /// </summary>
        public string TaskId { get; set; }
        public string CompanyId { get; set; }
        public Int32 Hours { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public Boolean Billable { get; set; }
        public string Meta { get; set; }
    }
}