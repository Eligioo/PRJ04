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

namespace Project_4_desktop.Graphs
{
    public class Question4b : PlotModel
    {
        public Question4b()
        {
            Title = "gestolen fietsen per kleur";

            var loader = new QuestionDataLoader<List<GetColor>>("questions/q4b");
            loader.OnLoaded += Loader_OnLoaded;
        }

        private void Loader_OnLoaded(object sender, EventArgs e)
        {
            var data = sender as List<GetColor>;

            var colorParts = new PieSeries
            {
                StrokeThickness = 2.0,
                InsideLabelPosition = 0.8,
                AngleSpan = 360,
                StartAngle = 0,
                Diameter = 0.9,
                FontSize = 13
            };

            colorParts.Slices.AddRange(data.Take(8).Select(color => new PieSlice(color.Color, color.Count)));
            var restCount = data.GetRange(8, data.Count - 8).Sum(color => color.Count);
            colorParts.Slices.Add(new PieSlice("Overig", restCount));

            Series.Add(colorParts);

            InvalidatePlot(true);
        }
    }
}
