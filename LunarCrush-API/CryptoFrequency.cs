using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;
using Api;

namespace Frequency
{

    public static class CryptoFrequency
    {
        private const string URL = "https://api.lunarcrush.com/v2?data=assets";
        private const string List = "https://api.lunarcrush.com/v2?data=market";
        private const string urlParameters = "&key=maba1tuhx6eib93jtv485&interval=day&data_points=31";

        public static List<string> GetCryptoNames()
        {
            var data = ApiConnection.ApiFetch(List, urlParameters, string.Empty, string.Empty);

            List<string> names = new List<string>();
            foreach (var name in data["data"])
            {
                names.Add((string)name["s"]);
            }
            return names;
        }

        public static int FrequencyCalculation(String input)
        {
            const string options = "&time_series_indicators=high";
            string symbol = "&symbol=" + input;
            var count = 0;

            try
            {
                var data = ApiConnection.ApiFetch(URL, urlParameters, symbol, options);
                var times = data["data"][0]["timeSeries"];
                List<double> timesHigh = new List<double>();
                foreach (var item in times)
                {
                    try
                    {
                        timesHigh.Add((double)item["high"]);
                    }
                    catch (Exception e)
                    {
                        timesHigh.Add(0);
                    }
                }
                var max = timesHigh.FirstOrDefault();
                timesHigh.ForEach(i =>
                {
                    if (i > max)
                    {
                        count++;
                        max = i;
                    }
                });
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("This currency does not exist on the API");
            }

            return count;
        }

        public static void CryptoFrequencyMonth(string choice)
        {
            Console.WriteLine(choice);
            Console.WriteLine("Frequency of new highs this month : " + FrequencyCalculation(choice));
            Console.WriteLine("");
        }

        public static void CryptoFrequencyTop()
        {
            List<string> names = GetCryptoNames();
            Random rnd = new Random();
            var randomNames = names.OrderBy(x => rnd.Next()).Take(10);

            List<Crypto> frequencies = new List<Crypto>();
            foreach (var name in randomNames)
            {

                frequencies.Add(new Crypto(FrequencyCalculation(name), name));
            }

            var top10 = frequencies.OrderByDescending(w => w.frequency).Take(10);
            foreach (var c in top10)
            {
                Console.WriteLine(c.name);
                Console.WriteLine("Frequency of new highs this month : " + c.frequency);
                Console.WriteLine("");
            }
        }
    }
}