using System.Collections.Generic;
using System.Linq;
using DeveloperDashboard.Models;
using Raven.Client;
using static DeveloperDashboard.DbRepository.NoSQL.NoSQL;

namespace DeveloperDashboard.DbRepository.CompanyCRUD
{
    public class NoSQLCompanyOperations : ICompanyOperations
    {
        public IEnumerable<Company> GetAllCompanies()
        {
            using (IDocumentSession session = RavenContext.CreateSession())
            {
                List<Company> companyList = session.Query<Company>()
                    .ToList();
                return companyList;
            }
        }
    }
}