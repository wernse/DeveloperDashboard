using System.Collections.Generic;
using System.Linq;
using DeveloperDashboard.App_Start;
using DeveloperDashboard.Models;
using Raven.Client;
using static DeveloperDashboard.DbRepository.NoSQL.NoSQL;

namespace DeveloperDashboard.DbRepository.CompanyCRUD
{
    public class NoSQLCompanyOperations : ICompanyOperations
    {
        public IEnumerable<Company> GetAllCompanies()
        {
            using (IDocumentSession session = RavenConfig.Store.OpenSession())
            {
                List<Company> companyList = session.Query<Company>()
                    .ToList();
                return companyList;
            }
        }
    }
}