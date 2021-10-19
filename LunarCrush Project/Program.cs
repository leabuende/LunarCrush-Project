using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConsoleProgram
{
    public class DataObject
    {
        public string Name { get; set; }
    }

    public class Program
    {
        private const string URL = "https://api.lunarcrush.com/v2?data=assets";
        private string urlParameters = "&key=maba1tuhx6eib93jtv485";
        private string symbol = "&symbol=LTC";

        static void Main(string[] args)
        {
            var program = new Program();

            var parameters = program.urlParameters + program.symbol;

            HttpClient client = new HttpClient();

            Console.WriteLine(client.BaseAddress);

            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(URL + parameters).Result;
            if (response.IsSuccessStatusCode)
            {
                var dataObjects = response.Content.ReadAsStringAsync().Result;
                JObject data = (JObject)JsonConvert.DeserializeObject(dataObjects);
                Console.Write(data["config"]);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            client.Dispose();
        }
    }
}
