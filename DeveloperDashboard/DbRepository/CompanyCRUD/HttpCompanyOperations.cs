using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DeveloperDashboard.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace DeveloperDashboard.DbRepository
{
    public class HttpCompanyOperations : ICompanyOperations
    {
        public IEnumerable<Company> GetAllCompanies()
        {
            using (HttpClient client = new HttpClient())
            {
                List<Company> companies = null;
                var response = client.GetAsync("http://developerdashboard.previewourapp.com/company/getAllCompanies").Result;
                if (response.IsSuccessStatusCode)
                {
                    // by calling .Result you are performing a synchronous call
                    var responseContent = response.Content.ReadAsStringAsync().Result;

                    companies = JsonConvert.DeserializeObject<List<Company>>(responseContent);
                }
                return companies;
            }
        }
    }
}