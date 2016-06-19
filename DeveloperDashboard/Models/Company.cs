using DeveloperDashboard.DbRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DeveloperDashboard.DbRepository.CompanyCRUD;

namespace DeveloperDashboard.Models
{
    public class Company
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Colour { get; set; }

        public IEnumerable<Company> GetAllCompanies()
        {
            //ICompanyOperations companyOperations = new SQLCompanyOperations();
            ICompanyOperations companyOperations = new NoSQLCompanyOperations();
            return companyOperations.GetAllCompanies();
        }
    }
}