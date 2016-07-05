using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.Xamarin.Forms;
using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinForms.Graphs;
using Newtonsoft.Json;
using BikeDataModels;
using System.Net.Http;
using Android.Util;
using Project4;

namespace XamarinForms
{
    public class Question1 : QuestionLoadPage<List<MostBikeContainer>>
    {
        public Question1() : base("questions/q1") { }

        protected override void OnCacheLoaded()
        {
            Title = "    buurten met meeste fietscontainers";
            var NeighbourhoodList = new List<Tuple<string, float>>();
            foreach (var item in Cache)
            {
                NeighbourhoodList.Add(new Tuple<string, float>(item.Neighborhoods, (float)item.Count));
            }
            var graphData = new GraphData<int>("De 5 buurten met de meeste fietstrommels",
                "Trommels", "buurt", new List<int>());
            GraphFactory<int> graphFactory = new GraphFactory<int>();
            PlotModel plotModel = graphFactory.createGraph(GraphType.Bar, new GraphEffect(), graphData);
            var bars = new BarSeries
            {
                Title = "Fietstrommels per buurt",
                StrokeColor = OxyColors.Black,
                StrokeThickness = 1
            };
            var categoryAxis = new CategoryAxis { Position = AxisPosition.Left };
            var valueAxis = new LinearAxis
            {
                Position = AxisPosition.Bottom,
                MinimumPadding = 0,
                MaximumPadding = 0.06,
                AbsoluteMinimum = 0
            };
            NeighbourhoodList.Sort(new TupleCompareClass().Compare);
            for (int i = 0; i < 5; i++)
            {
                bars.Items.Add(new BarItem { Value = NeighbourhoodList.ElementAt(i).Item2 });
                categoryAxis.Labels.Add(NeighbourhoodList.ElementAt(i).Item1);
            }
            plotModel.Series.Add(bars);
            plotModel.Axes.Add(categoryAxis);
            plotModel.Axes.Add(valueAxis);
            this.Content = new PlotView
            {
                BackgroundColor = Device.OnPlatform<Color>(Color.Default, Color.White, Color.Default),
                Model = plotModel
            };
        }
    }
}