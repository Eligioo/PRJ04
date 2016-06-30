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

namespace XamarinForms
{
    public class Question3 : ContentPage
    {
        readonly Picker picker;
        readonly List<Tuple<string, List<Tuple<int, int, int, int>>>> neighbourhoodList;
        private StackLayout layout;
        private PlotView barChart;
        private static bool loaded = false;
        private static List<CombinationofTheftTrommelAreaMonth> combinationList;
        public Question3()
        {
            if (!loaded)
            {
                loaded = true;
                Title = "         Vraag 3";
                using (var client = new HttpClient())
                {
                    string download = client.GetStringAsync("http://145.24.222.220/v2/questions/q3").Result;
                    combinationList = JsonConvert.DeserializeObject<List<CombinationofTheftTrommelAreaMonth>>(download);
                }
            }
            neighbourhoodList = new List<Tuple<string, List<Tuple<int, int, int, int>>>>();
            foreach (var neighbourhood in combinationList)
            {
                List<Tuple<int, int, int, int>> rows = new List<Tuple<int, int, int, int>>();
                foreach (var item in neighbourhood.Rows)
                {
                    rows.Add(new Tuple<int, int, int, int>(item.Thefts, item.Trommels, item.Month, item.Year));
                }
                neighbourhoodList.Add(new Tuple<string, List<Tuple<int, int, int, int>>>(neighbourhood.Neighbourhood, rows));
            }
            var graphData = new GraphData<int>("Wat zijn de 5 buurten met de meeste fietstrommels?",
                "Trommels", "buurt", new List<int>());
            GraphFactory<int> graphFactory = new GraphFactory<int>();
            var barModel = graphFactory.createGraph(GraphType.Bar, new GraphEffect(), graphData);
            var trommelBars = new BarSeries
            {
                Title = "Hoeveelheid Trommels",
                StrokeColor = OxyColors.Blue,
                StrokeThickness = 1
            };
            var theftBars = new BarSeries
            {
                Title = "Hoeveelheid diefstallen",
                StrokeColor = OxyColors.Red,
                StrokeThickness = 1
            };
            var categoryAxis = new CategoryAxis { Position = AxisPosition.Left };
            var valueAxis = new LinearAxis
            {
                Position = AxisPosition.Bottom,
                AbsoluteMinimum = 0
            };
            for (int i = 0; i < neighbourhoodList.Count; i++)
            {
                neighbourhoodList.ElementAt(i).Item2.Sort(new TupleCompareClass().Compare);
            }
            var bars = new BarSeries
            {
                Title = "Fietsdiefstallen en trommels per maand",
                StrokeColor = OxyColors.Black,
                StrokeThickness = 1
            };
            barModel.Series.Add(trommelBars);
            barModel.Series.Add(theftBars);
            barModel.Axes.Add(categoryAxis);
            barModel.Axes.Add(valueAxis);
            barChart = new PlotView
            {
                BackgroundColor = Color.White,
                Model = barModel
            };
            picker = new Picker
            {
                Title = "Buurten",
                VerticalOptions = LayoutOptions.Start
            };
            foreach (var item in neighbourhoodList)
            {
                picker.Items.Add(item.Item1);
            }
            var getButton = new Button { Text = "Laad" };
            getButton.Clicked += LoadButton_Clicked;
            layout = new StackLayout
            {
                Padding = new Thickness(50, 50, 50, 50),
                Children =
                {
                    picker,
                    getButton,
                    barChart
                }
            };
            this.Content = layout;
        }
        private void LoadButton_Clicked(object sender, EventArgs e)
        {
            var entry = neighbourhoodList.ElementAt(picker.SelectedIndex);
            var neighbourhood = entry.Item1;
            var data = entry.Item2;
            var trommelBars = new BarSeries
            {
                Title = "Hoeveelheid Trommels",
                StrokeColor = OxyColors.Blue,
                StrokeThickness = 1
            };
            var theftBars = new BarSeries
            {
                Title = "Hoeveelheid diefstallen",
                StrokeColor = OxyColors.Red,
                StrokeThickness = 1
            };
            var children = layout.Children.Take(layout.Children.Count - 1);
            IList<View> newChildren = new List<View>();
            foreach (var item in children)
            {
                newChildren.Add(item);
            }
            var graphData = new GraphData<int>("Wat zijn de 5 buurten met de meeste fietstrommels?",
                "Trommels", "buurt", new List<int>());
            GraphFactory<int> graphFactory = new GraphFactory<int>();
            var newBarModel = graphFactory.createGraph(GraphType.Bar, new GraphEffect(), graphData);
            foreach (var item in neighbourhoodList)
            {
                if (item.Item1 == neighbourhood)
                {
                    foreach (var combination in item.Item2)
                    {
                        theftBars.Items.Add(new BarItem { Value = combination.Item1 });
                        trommelBars.Items.Add(new BarItem { Value = combination.Item2 });
                        Log.Debug("BOBS ERRORS", "entry added");
                    }
                    newBarModel.Series.Add(theftBars);
                    newBarModel.Series.Add(trommelBars);
                    Log.Debug("BOBS ERRORS", "series added");
                    break;
                }
            }
            var categoryAxis = new CategoryAxis { Position = AxisPosition.Left };
            var valueAxis = new LinearAxis
            {
                Position = AxisPosition.Bottom,
                MinimumPadding = 0,
                MaximumPadding = 0.06,
                AbsoluteMinimum = 0
            };
            newBarModel.Axes.Add(categoryAxis);
            newBarModel.Axes.Add(valueAxis);
            var newPlotView = new PlotView
            {
                BackgroundColor = Color.White,
                Model = newBarModel
            };
            var newLayout = new StackLayout
            {
                Padding = new Thickness(50, 50, 50, 50)
            };
            newChildren.Add(newPlotView);
            foreach (var item in newChildren)
            {
                newLayout.Children.Add(item);
            }
            Log.Debug("BOBS ERRORS", "children = " + newLayout.Children.Count.ToString());
            this.Content = newLayout;
        }
    }
}