using BikeDataModels;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinForms.Graphs;

namespace Project_4_desktop.Graphs
{
    public class Question1 : PlotModel
    {
        public Question1()
        {
            Title = "De 5 buurten met de meeste fietstrommels";
            var loader = new QuestionDataLoader<List<MostBikeContainer>>("questions/q1");
            loader.OnLoaded += Loader_OnLoaded;
            loader.OnFailed += Loader_OnFailed;
        }

        private void Loader_OnFailed(object sender, EventArgs e)
        {
        }

        private void Loader_OnLoaded(object sender, EventArgs e)
        {
            var data = sender as List<MostBikeContainer>;

            var NeighbourhoodList = new List<Tuple<string, float>>();
            foreach (var item in data)
            {
                NeighbourhoodList.Add(new Tuple<string, float>(item.Neighborhoods, (float)item.Count));
            }
            var graphData = new GraphData<int>("De 5 buurten met de meeste fietstrommels",
                "Trommels", "buurt", new List<int>());
            GraphFactory<int> graphFactory = new GraphFactory<int>();
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
            Series.Add(bars);
            Axes.Add(categoryAxis);
            Axes.Add(valueAxis);

            InvalidatePlot(true);
        }
    }
}
