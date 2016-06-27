using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using OxyPlot.Xamarin.Android;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace AndroidApp
{
    public interface IGraphFactory
    {
        PlotModel createGraph(GraphType graphType, GraphEffect graphEffect, GraphData graphData);
    }
    public class TupleCompareClass : IComparer<Tuple<string, float>>
    {
        public int Compare(Tuple<string, float> x, Tuple<string, float> y)
        {
            if (x.Item2 < y.Item2)
            {
                return 1;
            }
            else if (x.Item2 == y.Item2)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
    }
    public class GraphData
    {
        public string graphTitle;
        public string xTitle;
        public string yTitle;
        public List<Tuple<string, float>> dataCollection;
        public GraphData(string GraphTitle, string XTitle, string YTitle, List<Tuple<string, float>> DataCollection)
        {
            this.graphTitle = GraphTitle;
            this.xTitle = XTitle;
            this.yTitle = YTitle;
            this.dataCollection = DataCollection;
        }
    }

    public enum GraphType
    {
        Bar, Line, Pie
    }
    public class GraphEffect
    {

    }
    public abstract class Graph
    {
        public GraphType graphType;
        public GraphEffect graphEffect;
        public GraphData graphData;

        protected Graph(GraphType GraphType, GraphEffect GraphEffect, GraphData GraphData)
        {
            this.graphType = GraphType;
            this.graphEffect = GraphEffect;
            this.graphData = GraphData;
        }
        public abstract PlotModel createChart();
    }

    public class BarChart : Graph
    {
        public BarChart(GraphType GraphType, GraphEffect GraphEffect, GraphData GraphData) : base(GraphType, GraphEffect, GraphData)
        {
            this.createChart();
        }
        public override PlotModel createChart()
        {
            var model = new PlotModel
            {
                Title = base.graphData.graphTitle,
                LegendPlacement = LegendPlacement.Outside,
                LegendPosition = LegendPosition.BottomCenter,
                LegendOrientation = LegendOrientation.Horizontal,
                LegendBorderThickness = 0
            };

            var s1 = new BarSeries {
                Title = base.graphData.graphTitle,
                StrokeColor = OxyColors.Black,
                StrokeThickness = 1
            };
            var categoryAxis = new CategoryAxis { Position = AxisPosition.Left };
            graphData.dataCollection.Sort(new TupleCompareClass().Compare);
            for (int i = 0; i < 5; i++)
            {
                s1.Items.Add(new BarItem { Value = graphData.dataCollection.ElementAt(i).Item2 });
                categoryAxis.Labels.Add(graphData.dataCollection.ElementAt(i).Item1);
            }
            var valueAxis = new LinearAxis {
                Position = AxisPosition.Bottom,
                MinimumPadding = 0,
                MaximumPadding = 0.06,
                AbsoluteMinimum = 0
            };
            model.Series.Add(s1);
            model.Axes.Add(categoryAxis);
            model.Axes.Add(valueAxis);

            return model;
        }
    }
    public class LineChart : Graph
    {
        public LineChart(GraphType GraphType, GraphEffect GraphEffect, GraphData GraphData) : base(GraphType, GraphEffect, GraphData)
        {
            this.createChart();
        }
        public override PlotModel createChart()
        {
            var plotModel = new PlotModel { Title = "OxyPlot Demo" };

            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom });
            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Maximum = 10, Minimum = 0 });

            var series1 = new LineSeries
            {
                MarkerType = MarkerType.Circle,
                MarkerSize = 4,
                MarkerStroke = OxyColors.White
            };

            series1.Points.Add(new DataPoint(0.0, 6.0));
            series1.Points.Add(new DataPoint(0.2, 6.0));
            series1.Points.Add(new DataPoint(0.3, 6.0));
            series1.Points.Add(new DataPoint(0.4, 6.0));
            series1.Points.Add(new DataPoint(0.5, 6.0));
            series1.Points.Add(new DataPoint(0.6, 6.0));
            series1.Points.Add(new DataPoint(0.7, 6.0));
            series1.Points.Add(new DataPoint(0.8, 6.0));
            series1.Points.Add(new DataPoint(0.9, 6.0));
            series1.Points.Add(new DataPoint(1.0, 6.0));
            series1.Points.Add(new DataPoint(1.4, 2.1));
            series1.Points.Add(new DataPoint(2.0, 4.2));
            series1.Points.Add(new DataPoint(3.3, 2.3));
            series1.Points.Add(new DataPoint(4.7, 7.4));
            series1.Points.Add(new DataPoint(6.0, 6.2));
            series1.Points.Add(new DataPoint(8.9, 8.9));

            plotModel.Series.Add(series1);

            return plotModel;
        }
    }

    public class PieChart : Graph
    {
        public PieChart(GraphType GraphType, GraphEffect GraphEffect, GraphData GraphData) : base(GraphType, GraphEffect, GraphData)
        {
            this.createChart();
        }
        public override PlotModel createChart()
        {
            PlotModel model = new PlotModel { Title = "Pie Sample1" };

            var seriesP1 = new PieSeries { StrokeThickness = 2.0, InsideLabelPosition = 0.8, AngleSpan = 360, StartAngle = 0 };

            seriesP1.Slices.Add(new PieSlice("Africa", 1030) { IsExploded = false, Fill = OxyColors.PaleVioletRed });
            seriesP1.Slices.Add(new PieSlice("Americas", 929) { IsExploded = true });
            seriesP1.Slices.Add(new PieSlice("Asia", 4157) { IsExploded = true });
            seriesP1.Slices.Add(new PieSlice("Europe", 739) { IsExploded = true });
            seriesP1.Slices.Add(new PieSlice("Oceania", 35) { IsExploded = true });

            model.Series.Add(seriesP1);
            return model;
        }
    }
    public class GraphFactory : IGraphFactory
    {
        Graph Chart;
        public PlotModel createGraph(GraphType graphType, GraphEffect graphEffect, GraphData graphData)
        {
            switch (graphType)
            {
                case GraphType.Line:
                    Chart = new LineChart(graphType, graphEffect, graphData);
                    break;
                case GraphType.Pie:
                    Chart = new PieChart(graphType, graphEffect, graphData);
                    break;
                default:
                    Chart = new BarChart(graphType, graphEffect, graphData);
                    break;
            }
            return Chart.createChart();
        }
    }
}