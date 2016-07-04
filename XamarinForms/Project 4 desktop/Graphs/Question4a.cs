using BikeDataModels;
using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinForms.Graphs;
using Project4.Extensions;
using OxyPlot.WindowsForms;

namespace Project_4_desktop.Graphs
{
    public class Question4a : PlotModel
    {
        public Question4a()
        {
            Title = "gestolen fietsen per merk";

            var loader = new QuestionDataLoader<List<GetBrand>>("questions/q4a");
            loader.OnLoaded += Loader_OnLoaded;

        }

        private void Loader_OnLoaded(object sender, EventArgs e)
        {
            var data = sender as List<GetBrand>;

            var brandParts = new PieSeries
            {
                StrokeThickness = 2.0,
                InsideLabelPosition = 0.8,
                AngleSpan = 360,
                StartAngle = 0,
                Diameter = 0.9,
                FontSize = 13
            };

            brandParts.Slices.AddRange(data.Take(8).Select(brandItem => new PieSlice(brandItem.Brand, brandItem.Count)));
            var restCount = data.GetRange(8, data.Count - 8).Sum(brand => brand.Count);
            brandParts.Slices.Add(new PieSlice("Overig", restCount));

            Series.Add(brandParts);

            InvalidatePlot(true);
        }
    }
}
