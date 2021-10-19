using System;
using System.Collections.Generic;
using Api;
using MathNet.Numerics.Statistics;

namespace Twitter
{
    public class TwitterCorrelation
    {
        private const string URL = "https://api.lunarcrush.com/v2?data=assets";

        public static void CorrelateData()
        {
            string urlParameters = "&key=maba1tuhx6eib93jtv485";
            long unixTimeNow = DateTimeOffset.Now.ToUnixTimeSeconds();
            long unixShift = 2629743;

            long unixDelay = unixTimeNow - unixShift;
            string options = "&interval=hour&data_points=720";
            string unixStart = options + "&start=" + unixDelay;

            Console.WriteLine("Please enter the crypto symbol (ex: BTC)");
            string symbolCoin = "&symbol=" + Console.ReadLine();

            var coin = ApiConnection.ApiFetch(URL, urlParameters, symbolCoin, unixStart);

            var coinData = coin["data"][0]["timeSeries"];

            List<double> volumes = new List<double>();
            List<double> tweets = new List<double>();
            List<double> socialScores = new List<double>();

            foreach (var item in coinData)
            {
                try
                {
                    volumes.Add((double)item["volume"]);
                    tweets.Add((double)item["tweets"]);
                    socialScores.Add((double)item["social_score"]);
                }
                catch (Exception)
                {
                    volumes.Add(0);
                    tweets.Add(0);
                    socialScores.Add(0);
                }
            }
            var correlationTweets = Correlation.Pearson(volumes, tweets);
            var correlationSocialScore = Correlation.Pearson(volumes, socialScores);

            Console.WriteLine("Tweets correlation:" + correlationTweets);
            Console.WriteLine("SocialScore correlation:" + correlationSocialScore);
        }
    }
}
