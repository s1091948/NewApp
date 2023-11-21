using NewsApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.Services
{
    class ApiService
    {

        public async Task<Root> GetNews(string categoryName)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync($"https://gnews.io/api/v4/top-headlines?country=tw&category={categoryName.ToLower()}&apikey=bc4ba7e4bb11f868a7eed90948baf77b");
            return JsonConvert.DeserializeObject<Root>(response);
        }
    }
}
