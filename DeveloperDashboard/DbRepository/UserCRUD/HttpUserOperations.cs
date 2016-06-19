using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DeveloperDashboard.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace DeveloperDashboard.DbRepository
{
    public class HttpUserOperations : IUserOperations
    {
        public IEnumerable<User> GetAllUsers()
        {
            using (HttpClient client = new HttpClient())
            {
                List<User> users = null;
                var response = client.GetAsync("http://developerdashboard.previewourapp.com/User/getAllUsers").Result;
                if (response.IsSuccessStatusCode)
                {
                    // by calling .Result you are performing a synchronous call
                    var responseContent = response.Content.ReadAsStringAsync().Result;

                    users = JsonConvert.DeserializeObject<List<User>>(responseContent);
                }
                return users;
            }
        }
    }
}