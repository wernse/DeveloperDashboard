using DeveloperDashboard.DbRepository.SQL;
using DeveloperDashboard.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DeveloperDashboard.DbRepository
{
    public class SQLCompanyOperations : ICompanyOperations 
    {
        /// <summary>
        /// <see cref="IEnumerable<Company> GetAllCompanies()"/>
        /// </summary>
        public IEnumerable<Company> GetAllCompanies()
        {
            using (ContextModel db = new ContextModel())
            {
                var query = from b in db.Companies
                            select b;

                return query.ToList();
            }
        }
  
    }
}