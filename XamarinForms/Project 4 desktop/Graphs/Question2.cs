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
    public class Question2 : PlotModel
    {
        public Question2()
        {
            Title = "Fietsdiefstallen per maand";

            var loader = new QuestionDataLoader<List<StolenBikeInMonthOfYear>>("questions/q2");
            loader.OnLoaded += Loader_OnLoaded;
        }

        private void Loader_OnLoaded(object sender, EventArgs e)
        {
            var data = sender as List<StolenBikeInMonthOfYear>;

            var BikeTheftList = new List<Tuple<int, int, int>>();
            foreach (var item in data)
            {
                BikeTheftList.Add(new Tuple<int, int, int>(item.StolenBikes, item.Month, item.Year));
            }
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
                AbsoluteMaximum = 2014,
                Maximum = 2014
            };
            var valueAxis = new LinearAxis
            {
                Position = AxisPosition.Left,
                TickStyle = TickStyle.Outside,
                Minimum = 0,
                Maximum = 400,
                AbsoluteMinimum = 0,
                AbsoluteMaximum = 550
            };
            BikeTheftList.Sort(new TupleCompareClass().Compare);
            foreach (var item in BikeTheftList)
            {
                points.Points.Add(new DataPoint((item.Item3 + (1.0 / 12.0 * item.Item2)), item.Item1));
            }
            for (int i = 1; i < 2026; i++)
            {
                categoryAxis.Labels.Add(i.ToString());
            }
            Series.Add(points);
            Axes.Add(valueAxis);
            Axes.Add(categoryAxis);

            InvalidatePlot(true);
        }
    }
}
