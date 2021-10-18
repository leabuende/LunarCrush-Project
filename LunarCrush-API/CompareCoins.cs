using System;
using System.Collections.Generic;
using System.Linq;
using Api;
using Table;
using Newtonsoft.Json.Linq;

namespace Compare
{
    public class CompareCoins
    {
        private const string URL = "https://api.lunarcrush.com/v2?data=assets";

        public static JToken RetrieveTimeSeries(JObject coin)
        {
            return coin["data"][0]["timeSeries"];
        }

        public static float DiffLowHigh(JToken coin)
        {
            List<float> low = new List<float>();
            List<float> high = new List<float>();

            foreach (var item in coin)
            {
                try
                {
                    low.Add((float)item["low"]);
                    high.Add((float)item["high"]);
                }
                catch (Exception)
                {
                    low.Add(0);
                    high.Add(0);
                }
            }
            var min = low.Min();
            var max = high.Max();
            return max - min;
        }

        public static float[] AverageOpeningClosing(JToken coin)
        {
            List<float> openings = new List<float>();
            List<float> closings = new List<float>();

            foreach (var item in coin)
            {
                try
                {
                    openings.Add((float)item["open"]);
                    closings.Add((float)item["close"]);
                }
                catch (Exception)
                {
                    openings.Add(0);
                    closings.Add(0);
                }
            }
            var averageOpening = openings.Average();
            var averageClosing = closings.Average();

            float[] averages = { averageOpening, averageClosing };

            return averages;
        }

        public static float ActualPrice(JObject coin)
        {
            return (float)coin["data"][0]["price"];
        }

        public static float MarketCap(JObject coin)
        {
            return (float)coin["data"][0]["market_cap"];
        }

        public static float MaxSupply(JObject coin)
        {
            return (float)coin["data"][0]["max_supply"];
        }

        public static float AverageVolume(JToken coin)
        {
            List<float> volumes = new List<float>();

            foreach (var item in coin)
            {
                try
                {
                    volumes.Add((float)item["volume"]);
                }
                catch (Exception)
                {
                    volumes.Add(0);
                }
            }
            var averageVolume = volumes.Average();

            return averageVolume;
        }

        public static float AverageVolatility(JToken coin)
        {
            List<float> volatilities = new List<float>();

            foreach (var item in coin)
            {
                try
                {
                    volatilities.Add((float)item["volatility"]);
                }
                catch (Exception)
                {
                    volatilities.Add(0);
                }
            }
            var averageVolatility = volatilities.Average();

            return averageVolatility;
        }

        public static void CompareCrypto()
        {
            string urlParameters = "&key=maba1tuhx6eib93jtv485";
            long unixTimeNow = DateTimeOffset.Now.ToUnixTimeSeconds();
            long unixShift = 31556926;

            long unixDelay = unixTimeNow - unixShift;
            string options = "&interval=day&data_points=365";
            string unixStart = options + "&start=" + unixDelay;

            Console.WriteLine("Please enter the crypto symbol (ex: BTC)");
            string symbolCoin1 = "&symbol=" + Console.ReadLine();

            Console.WriteLine("Please enter the crypto symbol (ex: BTC)");
            string symbolCoin2 = "&symbol=" + Console.ReadLine();

            var coin1 = ApiConnection.ApiFetch(URL, urlParameters, symbolCoin1, unixStart);
            var coin2 = ApiConnection.ApiFetch(URL, urlParameters, symbolCoin2, unixStart);

            TableChart.DrawTable(coin1, coin2);
        }
    }
}
