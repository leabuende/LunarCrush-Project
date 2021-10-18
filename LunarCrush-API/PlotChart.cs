using System;
using System.Collections.Generic;
using System.Linq;
using Plotly.NET;
using LunarCrush_API;

namespace ChartNet
{
    public class PlotChart
    {
        public static void PlotCrypto(List<int> timesHigh)
        {
            int[] x = Enumerable.Range(1, timesHigh.Count + 1).ToArray();
            int[] y = timesHigh.ToArray();
            GenericChart.GenericChart chart = Chart2D.Chart.Spline<int, int, string>(x: x, y: y, Smoothing: .2);
            chart
                .WithXAxisStyle(title: Title.init("xAxis"), ShowGrid: false, ShowLine: true)
                .WithYAxisStyle(title: Title.init("yAxis"), ShowGrid: false, ShowLine: true)
                .Show();
        }

        public static void PlotCryptoOfTheDay(List<Coin> list)
        {
            int[] values = new int[] { list[0].Cotd, list[1].Cotd, list[2].Cotd };
            string[] keys = new string[] { list[0].Symbol, list[1].Symbol, list[3].Symbol };

            // foreach (var item in list)
            // {
            //     values.Add(item.Cotd);
            //     keys.Add(item.Symbol);
            // }

            GenericChart.GenericChart chart = Chart2D.Chart.Bar(values, keys);
        }
    }
}