using DeveloperDashboard.Models;
using System.Data.Entity;

namespace DeveloperDashboard.DbRepository.SQL
{
    public class ContextModel : DbContext
    {
        public ContextModel() : base("DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer<ContextModel>(new InitializeDashboardSeedData());
        }
        /// <summary>
        /// Stores the company strings
        /// </summary>
        public DbSet<Company> Companies{ get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Task> Tasks { get; set; }

    }
}