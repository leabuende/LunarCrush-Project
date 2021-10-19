using System;
using System.Collections.Generic;
using Compare;
using Newtonsoft.Json.Linq;
using Plotly.NET;

namespace Table
{
    public class TableChart
    {
        public static void DrawTable(JObject coin1, JObject coin2)
        {
            JToken coin1Series = CompareCoins.RetrieveTimeSeries(coin1);
            JToken coin2Series = CompareCoins.RetrieveTimeSeries(coin2);

            string[] header = { "Type", "First Crypto", "Second Crypto" };

            string[][] headers = new string[][]
            {
                new string[] { "Type", },
                new string[] { "First Crypto", },
                new string[] { "Second Crypto", }
            };

            //List<List<string>> headers = new List<List<string>>();
            //headers.Add(new List<string>(header));

            string[][] averages = new string[][]
            {
                new string[] { "Diff low-high", CompareCoins.DiffLowHigh(coin1Series).ToString(), CompareCoins.DiffLowHigh(coin2Series).ToString() },
                new string[] { "Average opening", CompareCoins.AverageOpeningClosing(coin1Series)[0].ToString(), CompareCoins.AverageOpeningClosing(coin2Series)[0].ToString() },
                new string[] { "Average closing", CompareCoins.AverageOpeningClosing(coin1Series)[1].ToString(), CompareCoins.AverageOpeningClosing(coin2Series)[1].ToString() },
                new string[] { "Average volume", CompareCoins.AverageVolume(coin1Series).ToString(), CompareCoins.AverageVolume(coin2Series).ToString() },
                new string[] { "Average volatility", CompareCoins.AverageVolatility(coin1Series).ToString(), CompareCoins.AverageVolatility(coin2Series).ToString() },
                new string[] { "Actual price", CompareCoins.ActualPrice(coin1).ToString(), CompareCoins.ActualPrice(coin2).ToString() },
                new string[] { "Market cap", CompareCoins.MarketCap(coin1).ToString(), CompareCoins.MarketCap(coin2).ToString() },
                new string[] { "Max supply", CompareCoins.MaxSupply(coin1).ToString(), CompareCoins.MaxSupply(coin2).ToString() }
            };

            GenericChart.GenericChart chart = ChartDomain.Chart.Table<string[], string, string[], string>(headerValues: headers, cellValues: averages);
            chart.Show();
        }
    }
}
