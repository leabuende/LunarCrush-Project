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
        public static readonly string apiKey = "&key=maba1tuhx6eib93jtv485";

        public static JObject ApiFetch(string URL, string urlParameters, string options, string symbol)
        {
            var parameters = urlParameters + symbol + options;

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
