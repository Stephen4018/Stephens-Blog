using Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class MockService : IMockService
    {
        public async Task<List<Datas>> GetExternalBlog()
        {
            using(HttpClient httpClient = new HttpClient()) 
            {
                //var Url = "https://mocki.io/v1/d33691f7-1eb5-45aa-9642-8d538f6c5ebd";
                var Url = "https://localhost:44383/api/Contact_API_?PageNumber=1&PageSize=3";
                var Request = await httpClient.GetAsync(Url);

                var message = await Request.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<Mock> (message);
                return result.data.ToList();
            }
        }
    }
}
