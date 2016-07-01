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
    public class Question4 : CarouselPage
    {
        private static bool loaded = false;
        private static List<GetBrand> mostBrands;
        private static List<GetColor> mostColors;
        public Question4()
        {
            Title = "    Vraag 4";
            if (!loaded)
            {
                this.LoadData();
                this.ShowLoading();
            }else
            {
                this.ShowData();
            }
        }
        private void ShowLoading()
        {
            var loadingScreen = new ActivityIndicator { HorizontalOptions = LayoutOptions.CenterAndExpand, Color = Color.White, IsVisible = true, IsRunning = true };
            this.Children.Add(new ContentPage
            {
                Content = loadingScreen
            });
        }
        private async void LoadData()
        {
            using (var client = new HttpClient())
            {
                string download = await client.GetStringAsync("http://145.24.222.220/v2/questions/q4a");
                mostBrands = JsonConvert.DeserializeObject<List<GetBrand>>(download);
                download = client.GetStringAsync("http://145.24.222.220/v2/questions/q4b").Result;
                mostColors = JsonConvert.DeserializeObject<List<GetColor>>(download);
            }
            loaded = true;
            Children.Clear();
            this.ShowData();
        }
        private void ShowData()
        {
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
            var graphDataBrand = new GraphData<int>("Fietsdiefstallen per merk?", "Diefstallen", "Merk", new List<int>());
            var graphDataColor = new GraphData<int>("Fietsdiefstallen per kleur?", "Diefstallen", "Kleur", new List<int>());
            GraphFactory<int> graphFactory = new GraphFactory<int>();
            PlotModel plotModel = graphFactory.createGraph(GraphType.Pie, new GraphEffect(), graphDataBrand);
            PlotModel plotModel2 = graphFactory.createGraph(GraphType.Pie, new GraphEffect(), graphDataColor);
            var brandParts = new PieSeries
            {
                StrokeThickness = 2.0,
                InsideLabelPosition = 0.8,
                AngleSpan = 360,
                StartAngle = 0,
                Diameter = 0.9,
                FontSize = 13
            };
            var colorParts = new PieSeries
            {
                StrokeThickness = 2.0,
                InsideLabelPosition = 0.8,
                AngleSpan = 360,
                StartAngle = 0,
                Diameter = 0.9,
                FontSize = 13
            };
            for (int i = 0; i < 8; i++)
            {
                brandParts.Slices.Add(new PieSlice(mostBrandsList.ElementAt(i).Item1, mostBrandsList.ElementAt(i).Item2));
            }
            int overigCount = 0;
            for (int i = 8; i < mostBrandsList.Count - 1; i++)
            {
                overigCount = overigCount + mostBrandsList.ElementAt(i).Item2;
            }
            brandParts.Slices.Add(new PieSlice("Overig", overigCount));
            for (int i = 0; i < 8; i++)
            {
                colorParts.Slices.Add(new PieSlice(mostColorsList.ElementAt(i).Item1, mostColorsList.ElementAt(i).Item2));
            }
            for (int i = 8; i < mostColorsList.Count - 1; i++)
            {
                overigCount = overigCount + mostColorsList.ElementAt(i).Item2;
            }
            colorParts.Slices.Add(new PieSlice("Overig", overigCount));
            plotModel.Series.Add(brandParts);
            plotModel2.Series.Add(colorParts);
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
            var padding = new Thickness(0, 0, 0, 0);
            var redContentPage = new ContentPage
            {
                Padding = padding,
                Content = new PlotView
                {
                    BackgroundColor = Color.White,
                    Model = plotModel
                }
            };
            var greenContentPage = new ContentPage
            {
                Padding = padding,
                Content = new PlotView
                {
                    BackgroundColor = Color.White,
                    Model = plotModel2
                }
            };
            Children.Add(redContentPage);
            Children.Add(greenContentPage);
        }
    }
}