using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using ChartNet;
using Api;

namespace LunarCrush_API
{
    public static class CoinOfTheDay
    {
        public static readonly string URL = "https://api.lunarcrush.com/v2?data=coinoftheday";
        public static readonly string FullInfoURL = "https://api.lunarcrush.com/v2?data=coinoftheday_info";
        public static void get()
        {
            var response = ApiConnection.ApiFetch(URL, ApiConnection.apiKey, null, null);
            Console.WriteLine(response["data"]["symbol"] + " is the coin of the day !");
        }
        public static void getFullInfo()
        {
            var response = ApiConnection.ApiFetch(FullInfoURL, ApiConnection.apiKey, null, null);
            JArray responseList = (JArray)response["data"]["history"];
            List<Coin> coinsList = new List<Coin>();

            Console.WriteLine("\n\n Top 3 coins of the day ! \n");
            for (int i = responseList.Count - 1; i > responseList.Count - 4; i--)
            {
                var rank = responseList.Count - i;
                coinsList.Add(new Coin(responseList[i]["symbol"].ToString(), int.Parse(responseList[i]["last_cotd"].ToString())));
                Console.WriteLine(rank + " : " + responseList[i]["symbol"] + " - " + responseList[i]["name"]);
            }

            // PlotChart.PlotCryptoOfTheDay(coinsList);
        }
    }
}