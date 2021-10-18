using System;
using System.Collections.Generic;
using System.Linq;
using Plotly.NET;

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
    }
}
