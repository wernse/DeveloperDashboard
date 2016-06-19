using DeveloperDashboard.Models;
using System.Collections.Generic;

namespace DeveloperDashboard.DbRepository
{
    interface ICompanyOperations
    {
        /// <summary>
        /// Gets all companies within the db
        /// </summary>
        /// <returns>A IEnumerable Company object</returns>
        IEnumerable<Company> GetAllCompanies();
    }
}
