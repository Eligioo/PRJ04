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
    public partial class Question4Page : ContentPage
    {
        private static bool loaded = false;
        private static List<GetBrand> mostBrands;
        private static List<GetColor> mostColors;
        public Question4Page()
        {
            //InitializeComponent();
            if (!loaded)
            {
                loaded = true;
                Title = "    Question 2";
                using (var client = new HttpClient())
                {
                    string download = client.GetStringAsync("http://145.24.222.220/v2/questions/q4a").Result;
                    mostBrands = JsonConvert.DeserializeObject<List<GetBrand>>(download);
                    download = client.GetStringAsync("http://145.24.222.220/v2/questions/q4b").Result;
                    mostColors = JsonConvert.DeserializeObject<List<GetColor>>(download);
                }
            }
            List<Tuple<string, int>> mostBrandsList = new List<Tuple<string, int>>();
            List<Tuple<string, int>> mostColorsList = new List<Tuple<string, int>>();
            foreach (var item in mostBrands)
            {
                mostBrandsList.Add(new Tuple<string, int>(item.Brand, item.Count));
            }
            foreach (var item in mostColors)
            {
                mostColorsList.Add(new Tuple<string, int>(item.Color, item.Count));
            }
            var graphData = new GraphData<int>("Hoeveel fietsdiefstallen zijn er per merk?", "Hoeveelheid", "Merk", new List<int>());
            GraphFactory<int> graphFactory = new GraphFactory<int>();
            PlotModel plotModel = graphFactory.createGraph(GraphType.Pie, new GraphEffect(), graphData);
            PlotModel plotModel2 = graphFactory.createGraph(GraphType.Pie, new GraphEffect(), graphData);
            var brandParts = new PieSeries
            {
                StrokeThickness = 2.0,
                InsideLabelPosition = 0.8,
                AngleSpan = 180,
                StartAngle = 0,
                Diameter = 1.0
            };
            var colorParts = new PieSeries
            {
                StrokeThickness = 2.0,
                InsideLabelPosition = 0.8,
                AngleSpan = 180,
                StartAngle = 180,
                Diameter = 1.0
            };
            for (int i = 0; i < 7; i++)
            {
                brandParts.Slices.Add(new PieSlice(mostBrandsList.ElementAt(i).Item1, mostBrandsList.ElementAt(i).Item2));
            }
            brandParts.Slices.Add(new PieSlice("Overig", mostBrandsList.GetRange(10, mostBrandsList.Count - 11).Count));
            for (int i = 0; i < 7; i++)
            {
                colorParts.Slices.Add(new PieSlice(mostColorsList.ElementAt(i).Item1, mostColorsList.ElementAt(i).Item2));
            }
            colorParts.Slices.Add(new PieSlice("Overig", mostColorsList.GetRange(10, mostColorsList.Count - 11).Count));
            plotModel.Series.Add(brandParts);
            //plotModel.Title = "randomtitle"; this doesnt work either
            plotModel2.Series.Add(colorParts);
            var viewList = new ListView();
            var plotView = new PlotView
            {
                BackgroundColor = Color.White,
                Model = plotModel
            };
            var plotView2 = new PlotView
            {
                BackgroundColor = Color.White,
                Model = plotModel2
            };
        }
    }
}
