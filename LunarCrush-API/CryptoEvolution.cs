using System;
using System.Collections.Generic;
using System.Linq;
using Api;

namespace Evolution
{
    public static class CryptoEvolution
    {
        private const string URL = "https://api.lunarcrush.com/v2?data=assets";

        public static void CryptoEvolutionHour(string choice)
        {
            string urlParameters = string.Empty;
            long unixTimeNow = DateTimeOffset.Now.ToUnixTimeSeconds();
            long unixShift = 0;

            if (string.Compare(choice, "d") == 0)
            {
                urlParameters = "&key=maba1tuhx6eib93jtv485&interval=day&data_points=7";
                unixShift = 604800;
            }
            else
            {
                urlParameters = "&key=maba1tuhx6eib93jtv485&interval=hour&data_points=24";
                unixShift = 86400;
            }

            long unixDelay = unixTimeNow - unixShift;
            string options = "&time_series_indicators=high";
            string unixStart = options + "&start=" + unixDelay;
            Console.WriteLine(unixStart);

            Console.WriteLine("Please enter the crypto symbol (ex: BTC)");
            string symbol = "&symbol=" + Console.ReadLine();

            var data = ApiConnection.ApiFetch(URL, urlParameters, symbol, unixStart);
            var times = data["data"][0]["timeSeries"];
            List<int> timesHigh = new List<int>();

            foreach (var item in times)
            {
                try
                {
                    timesHigh.Add((int)item["high"]);
                }
                catch (Exception)
                {
                    timesHigh.Add(0);
                }
            }
            timesHigh.ForEach(i => Console.Write("{0}\t", i));
            var maxIndex = timesHigh.IndexOf(timesHigh.Max()) + 1;

            if (string.Compare(choice, "d") == 0)
            {
                int days = 7 - maxIndex;
                if (days == 0)
                {
                    Console.WriteLine("The max was reached today at $" + timesHigh.Max() + ".");
                }
                else
                {
                    Console.WriteLine("The max was reached " + days + " day(s) ago at $" + timesHigh.Max() + ".");
                }
            }
            else
            {
                int hours = 24 - maxIndex;
                if (hours == 0)
                {
                    Console.WriteLine("The max was reached this hour at $" + timesHigh.Max() + ".");
                }
                else
                {
                    Console.WriteLine("The max was reached " + hours + " hour(s) ago at $" + timesHigh.Max() + ".");
                }
            }
        }
    }
}
