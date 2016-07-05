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
    public class Question3 : CarouselPage
    {
        private Picker picker;
        private bool isLoading = false;
        private List<Tuple<string, List<Tuple<int, int, int, int>>>> neighbourhoodList;
        private StackLayout layout;
        private PlotView barChart;
        private static bool loaded = false;
        private static List<CombinationofTheftTrommelAreaMonth> combinationList;
        public Question3()
        {
            Title = "    fiets trommels/diefstallen per maand";
            if (!loaded)
            {
                this.LoadData();
                this.ShowLoading();

            } else
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
                var download = await client.GetStringAsync("http://145.24.222.220/v2/questions/q3");
                combinationList = JsonConvert.DeserializeObject<List<CombinationofTheftTrommelAreaMonth>>(download);
                loaded = true;
                this.ShowData();
            }
        }
        private void ShowData()
        {

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
            var graphData = new GraphData<int>("Fietstrommels en diefstallen per maand",
                "Trommels", "Buurt", new List<int>());
            GraphFactory<int> graphFactory = new GraphFactory<int>();
            var barModel = graphFactory.createGraph(GraphType.Bar, new GraphEffect(), graphData);
            var trommelBars = new BarSeries
            {
                Title = "Hoeveelheid trommels",
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
            var getButton = new Button { Text = "Laad", VerticalOptions = LayoutOptions.Start };
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
            Children.Clear();
            var contentPage = new ContentPage
            {
                Content = layout
            };
            Children.Add(contentPage);
        }
        private void LoadButton_Clicked(object sender, EventArgs e)
        {

            if (picker.SelectedIndex != -1 && isLoading == false)
            {
                isLoading = true;
                var entry = neighbourhoodList.ElementAt(picker.SelectedIndex);
                var neighbourhood = entry.Item1;
                var data = entry.Item2;
                var trommelBars = new BarSeries
                {
                    Title = "Hoeveelheid trommels",
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
                var graphData = new GraphData<int>("diefstallen en fietstrommels per maand",
                    "Trommels", "Buurt", new List<int>());
                GraphFactory<int> graphFactory = new GraphFactory<int>();
                var newBarModel = graphFactory.createGraph(GraphType.Bar, new GraphEffect(), graphData);
                var categoryAxis = new CategoryAxis
                {
                    Position = AxisPosition.Left,
                    AbsoluteMinimum = 0
                };
                var valueAxis = new LinearAxis
                {
                    Position = AxisPosition.Bottom,
                    MinimumPadding = 0,
                    MaximumPadding = 0.06,
                    AbsoluteMinimum = 0
                };
                foreach (var item in neighbourhoodList)
                {
                    if (item.Item1 == neighbourhood)
                    {
                        var labelList = new List<string>();
                        for (int i = 48; i > 0; i--)
                        {
                            labelList.Add(((i + 5) % 12 + 1).ToString() + " - " + (((int)(Math.Floor((float)i + 5) / 12) + 2009).ToString()));
                        }
                        labelList.Reverse();
                        for (int i = 0; i < labelList.Count*2; i++)
                        {
                            if (i % 2 == 0)
                            {
                                categoryAxis.Labels.Add(labelList.ElementAt((int)Math.Ceiling((float)i / 2)));
                            }else
                            {
                                categoryAxis.Labels.Add("");
                            }
                        }
                        for (int i = 0; i < 48; i++)
                        {
                            if (item.Item2.Count() > i)
                            {
                                theftBars.Items.Add(new BarItem { Value = item.Item2.ElementAt(i).Item1, Color = OxyPlot.OxyColor.FromRgb((byte)255, (byte)0, (byte)0) });
                                theftBars.Items.Add(new BarItem { Value = 0 });
                            }
                            else
                            {
                                theftBars.Items.Add(new BarItem { Value = 0 });
                                theftBars.Items.Add(new BarItem { Value = 0 });
                            }
                            if (item.Item2.Count() > i)
                            {
                                trommelBars.Items.Add(new BarItem { Value = 0 });
                                trommelBars.Items.Add(new BarItem { Value = item.Item2.ElementAt(i).Item2, Color = OxyPlot.OxyColor.FromRgb((byte)0, (byte)0, (byte)255) });
                            }
                            else
                            {
                                trommelBars.Items.Add(new BarItem { Value = 0 });
                                trommelBars.Items.Add(new BarItem { Value = 0 });
                            }
                        }
                        newBarModel.Series.Add(theftBars);
                        newBarModel.Series.Add(trommelBars);
                        break;
                    }
                }
                newBarModel.Axes.Add(categoryAxis);
                newBarModel.Axes.Add(valueAxis);
                var newLayout = new StackLayout
                {
                    Padding = new Thickness(50, 50, 50, 50)
                };
                foreach (var item in newChildren)
                {
                    newLayout.Children.Add(item);
                }
                var contentPage = new ContentPage
                {
                    Content = new PlotView
                    {
                        BackgroundColor = Color.White,
                        Model = newBarModel,
                        HeightRequest = 0.5,
                        WidthRequest = 0.5,
                    },
                    BackgroundColor = Color.White
                };
                var selectPage = new StackLayout { Padding = new Thickness(50, 50, 50, 50) };
                foreach (var item in newChildren)
                {
                    selectPage.Children.Add(item);
                }
                Children.Clear();
                Children.Add(new ContentPage { Content = selectPage });
                Children.Add(contentPage);
                isLoading = false;
            }
        }
    }
}