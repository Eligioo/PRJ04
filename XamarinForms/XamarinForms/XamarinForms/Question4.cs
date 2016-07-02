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

using Project4.Extensions;
using Project4;

namespace XamarinForms
{
    public class Question4 : CarouselPage
    {
        public Question4()
        {
            Title = "    Vraag 4";
            this.Children.Add(new BrandPie());
            this.Children.Add(new ColorPie());            
        }
        
        private class BrandPie : QuestionLoadPage<List<GetBrand>>
        {
            public BrandPie() : base("questions/q4a") { }

            protected override void OnCacheLoaded()
            {
                var graphDataBrand = new GraphData<int>("Fietsdiefstallen per merk?", "Diefstallen", "Merk", new List<int>());
                GraphFactory<int> graphFactory = new GraphFactory<int>();
                PlotModel plotModel = graphFactory.createGraph(GraphType.Pie, new GraphEffect(), graphDataBrand);

                var brandParts = new PieSeries
                {
                    StrokeThickness = 2.0,
                    InsideLabelPosition = 0.8,
                    AngleSpan = 360,
                    StartAngle = 0,
                    Diameter = 0.9,
                    FontSize = 13
                };

                brandParts.Slices.AddRange(Cache.Take(8).Select(brandItem => new PieSlice(brandItem.Brand, brandItem.Count)));
                var restCount = Cache.GetRange(8, Cache.Count - 8).Sum(brand => brand.Count);
                brandParts.Slices.Add(new PieSlice("Overig", restCount));

                plotModel.Series.Add(brandParts);

                var plotView = new PlotView
                {
                    BackgroundColor = Color.White,
                    Model = plotModel
                };

                Padding = new Thickness(0, 0, 0, 0);
                Content = new PlotView
                {
                    BackgroundColor = Color.White,
                    Model = plotModel
                };
            }
        }

        private class ColorPie : QuestionLoadPage<List<GetColor>>
        {
            public ColorPie() : base("questions/q4b") { }

            protected override void OnCacheLoaded()
            {
                var graphDataColor = new GraphData<int>("Fietsdiefstallen per kleur?", "Diefstallen", "Kleur", new List<int>());
                GraphFactory<int> graphFactory = new GraphFactory<int>();
                PlotModel plotModel = graphFactory.createGraph(GraphType.Pie, new GraphEffect(), graphDataColor);

                var colorParts = new PieSeries
                {
                    StrokeThickness = 2.0,
                    InsideLabelPosition = 0.8,
                    AngleSpan = 360,
                    StartAngle = 0,
                    Diameter = 0.9,
                    FontSize = 13
                };


                colorParts.Slices.AddRange(Cache.Take(8).Select(color => new PieSlice(color.Color, color.Count)));
                var restCount = Cache.GetRange(8, Cache.Count - 8).Sum(color => color.Count);
                colorParts.Slices.Add(new PieSlice("Overig", restCount));



                plotModel.Series.Add(colorParts);
                var plotView2 = new PlotView
                {
                    BackgroundColor = Color.White,
                    Model = plotModel
                };
                Padding = new Thickness(0, 0, 0, 0);
                Content = new PlotView
                {
                    BackgroundColor = Color.White,
                    Model = plotModel
                };
            }
        }
    }
}