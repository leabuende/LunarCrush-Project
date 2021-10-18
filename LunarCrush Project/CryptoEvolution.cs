using System;
using System.Collections.Generic;
using System.Linq;
using Api;

namespace Evolution
{
    public static class CryptoEvolution
    {
        private const string URL = "https://api.lunarcrush.com/v2?data=assets";

        public static int CryptoEvolutionHour(string choice)
        {
            string urlParameters = string.Empty;
            long unixTimeNow = DateTimeOffset.Now.ToUnixTimeSeconds();
            long unixShift = 0;

            if (string.Compare(choice, "d") == 0)
            {
                urlParameters = "&key=maba1tuhx6eib93jtv485&interval=day&data_points=7";
                unixShift = 86400;
            }
            else
            {
                urlParameters = "&key=maba1tuhx6eib93jtv485&interval=hour&data_points=24";
                unixShift = 604800;
            }

            long unixDelay = unixTimeNow - unixShift;
            const string options = "&time_series_indicators=high";


            Console.WriteLine("Please enter the crypto symbol (ex: BTC)");
            string symbol = "&symbol=" + Console.ReadLine();

            var data = ApiConnection.ApiFetch(URL, urlParameters, symbol, options);
            var times = data["data"][0]["timeSeries"];
            List<int> timesHigh = new List<int>();

            foreach (var item in times)
            {
                timesHigh.Add((int)item["high"]);
            }
            timesHigh.ForEach(i => Console.Write("{0}\t", i));
            var maxIndex = timesHigh.IndexOf(timesHigh.Max());

            Console.Write("The max was reached at the hour:");
            Console.WriteLine(maxIndex);

            return 0;
        }
    }
}