using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Api
{
    public class DataObject
    {
        public string Name { get; set; }
    }

    public static class ApiConnection
    {
        private const string URL = "https://api.lunarcrush.com/v2?data=assets";
        private const string urlParameters = "&key=maba1tuhx6eib93jtv485";
        private const string symbol = "&symbol=LTC";

        public static JObject ApiFetch()
        {
            var parameters = urlParameters + symbol;

            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(URL + parameters).Result;
            if (response.IsSuccessStatusCode)
            {
                var dataObjects = response.Content.ReadAsStringAsync().Result;
                JObject data = (JObject)JsonConvert.DeserializeObject(dataObjects);
                client.Dispose();
                return data;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return null;
            }
        }
    }
}
