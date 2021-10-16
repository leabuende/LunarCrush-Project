using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Lunarcrush_Project
{
    public class DataObject
    {
        public string Name { get; set; }
    }

    public class Program
    {
 
        static void Main(string[] args)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://dog.ceo/api/breeds/list/");
                //HTTP GET
                var responseTask = client.GetAsync("all");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<object>();
                    readTask.Wait();

                    var dogs = JsonConvert.DeserializeObject(readTask.Result.ToString());
                    Console.Write(dogs);
                }
            }
            Console.ReadLine();
        } 
    }
}