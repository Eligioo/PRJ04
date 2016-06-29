using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.Xamarin.Forms;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using XamarinForms.Graphs;
using Newtonsoft.Json;
using BikeDataModels;
using System.Net.Http;
using Android.Util;

namespace XamarinForms
{
    public class Question2 : ContentPage
    {
        private static bool loaded = false;
        private static List<StolenBikeInMonthOfYear> mostTrommelList;
        public Question2()
        {
            if (!loaded)
            {
                loaded = true;
                Title = "    Question 2";
                using (var client = new HttpClient())
                {
                    string download = client.GetStringAsync("http://145.24.222.220/v2/questions/q2").Result;
                    mostTrommelList = JsonConvert.DeserializeObject<List<StolenBikeInMonthOfYear>>(download);
                }
            }
            var BikeTheftList = new List<Tuple<int, int, int>>();
            foreach (var item in mostTrommelList)
            {
                BikeTheftList.Add(new Tuple<int, int, int>(item.StolenBikes, item.Month, item.Year));
            }
            var graphData = new GraphData<int>("Hoeveel fietsdiefstallen zijn er per maand?",
                "Trommels", "maand", new List<int>());
            GraphFactory<int> graphFactory = new GraphFactory<int>();
            PlotModel plotModel = graphFactory.createGraph(GraphType.Line, new GraphEffect(), graphData);
            var points = new LineSeries
            {
                Title = "Fietsdiefstallen per maand",
                MarkerType = MarkerType.Circle,
                MarkerSize = 4,
                MarkerStroke = OxyColors.White
            };
            var categoryAxis = new CategoryAxis
            {
                Position = AxisPosition.Bottom,
                TickStyle = TickStyle.Outside,
                AbsoluteMinimum = 2011,
                AbsoluteMaximum = 2014
            };
            var valueAxis = new LinearAxis
            {
                Position = AxisPosition.Left,
                TickStyle = TickStyle.Outside,
                AbsoluteMinimum = 175,
                AbsoluteMaximum = 500
            };
            BikeTheftList.Sort(new TupleCompareClass().Compare);
            foreach (var item in BikeTheftList)
            {
                points.Points.Add(new DataPoint((item.Item3 + (1.0 / 12.0 * item.Item2)), item.Item1));
                Log.Debug("DEBUG MESSAGES BROUGHT TO YOU BY BOB", (new DataPoint((item.Item3 + (1.0 / 12.0 * item.Item2)), item.Item1)).ToString());
            }
            for (int i = 1; i < 2026; i++)
            {
                categoryAxis.Labels.Add(i.ToString());
            }
            plotModel.Series.Add(points);
            plotModel.Axes.Add(valueAxis);
            plotModel.Axes.Add(categoryAxis);
            this.Content = new PlotView
            {
                BackgroundColor = Color.White,
                Model = plotModel
            };
        }
    }
}