using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using JsonSerilizerASP.Models;

namespace JsonSerilizerASP.Utils
{
    public class CustomHttpClient
    {
        public static async Task<IList<PropertyData>> GetAsync()
        {
            string responseString;

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("http://dev1-sample.azurewebsites.net/properties.json");
                responseString = await response.Content.ReadAsStringAsync();
            }

            var responseJson = JsonConvert.DeserializeObject<IList<PropertyData>>(
                responseString, new PropertyConverter());

            return responseJson;
        }
    }
}
