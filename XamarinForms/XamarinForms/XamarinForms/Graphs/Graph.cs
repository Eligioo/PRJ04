﻿using System;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System.Collections.Generic;
using Android.Util;

namespace XamarinForms.Graphs
{
    public interface iGraphFactory<T>
    {
        PlotModel createGraph(GraphType graphType, GraphEffect graphEffect, GraphData<T> graphData);
    }
    public class TupleCompareClass : IComparer<Tuple<string, float>>
    {
        public int Compare(Tuple<int, int, int, int> x, Tuple<int, int, int, int> y)
        {
            if (x.Item4 < y.Item4)
            {
                return 1;
            }
            else if (x.Item4 == y.Item4)
            {
                if (x.Item3 < y.Item3)
                {
                    return 1;
                }
                else if (x.Item3 > y.Item3)
                {
                    return -1;
                }
                return 0;
            }
            else
            {
                return -1;
            }
        }
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
        public int Compare(Tuple<int, int, int> x, Tuple<int, int, int> y)
        {
            if (x.Item3 < y.Item3)
            {
                return 1;
            }
            else if (x.Item3 == y.Item3)
            {
                if (x.Item2 < y.Item2)
                {
                    return 1;
                }else if(x.Item2 == y.Item2)
                {
                    return 0;
                }
                return -1;
            }
            else
            {
                return -1;
            }
        }
    }
    public class GraphData<T>
    {
        public string graphTitle;
        public string xTitle;
        public string yTitle;
        public List<T> dataCollection;

        public GraphData(string GraphTitle, string XTitle, string YTitle, List<T> DataCollection)
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
    public abstract class Graph<T>
    {
        public GraphType graphType { get; }
        public GraphEffect graphEffect { get; }
        public GraphData<T> graphData { get; }

        protected Graph(GraphType GraphType, GraphEffect GraphEffect, GraphData<T> GraphData)
        {
            this.graphType = GraphType;
            this.graphEffect = GraphEffect;
            this.graphData = GraphData;
        }
        public abstract PlotModel createChart();
    }

    public class BarChart<T> : Graph<T>
    {
        public BarChart(GraphType GraphType, GraphEffect GraphEffect, GraphData<T> GraphData) : base(GraphType, GraphEffect, GraphData)
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
            /*
            var s1 = new BarSeries
            {
                Title = base.graphData.graphTitle,
                StrokeColor = OxyColors.Black,
                StrokeThickness = 1
            };

            fo
            //s1.Items.Add(new BarItem { Value = 40 });
            //var categoryAxis = new CategoryAxis { Position = AxisPosition.Left };
            //categoryAxis.Labels.Add("Category D");
            var valueAxis = new LinearAxis
            {
                Position = AxisPosition.Bottom,
                MinimumPadding = 0,
                MaximumPadding = 0.06,
                AbsoluteMinimum = 0
            };
            model.Series.Add(s1);
            model.Axes.Add(categoryAxis);
            model.Axes.Add(valueAxis);
            */
            return model;
        }
    }
    public class LineChart<T> : Graph<T>
    {
        public LineChart(GraphType GraphType, GraphEffect GraphEffect, GraphData<T> GraphData) : base(GraphType, GraphEffect, GraphData)
        {
            this.createChart();
        }
        public override PlotModel createChart()
        {
            var plotModel = new PlotModel { Title = base.graphData.graphTitle };
            /*
            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom });
            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Maximum = 10, Minimum = 0 });

            var series1 = new LineSeries
            {
                MarkerType = MarkerType.Circle,
                MarkerSize = 4,
                MarkerStroke = OxyColors.White
            };

            series1.Points.Add(new DataPoint(0.0, 6.0));
            series1.Points.Add(new DataPoint(1.4, 2.1));
            series1.Points.Add(new DataPoint(2.0, 4.2));
            series1.Points.Add(new DataPoint(3.3, 2.3));
            series1.Points.Add(new DataPoint(4.7, 7.4));
            series1.Points.Add(new DataPoint(6.0, 6.2));
            series1.Points.Add(new DataPoint(8.9, 8.9));

            plotModel.Series.Add(series1);
            */
            return plotModel;
        }
    }

    public class PieChart<T> : Graph<T>
    {
        public PieChart(GraphType GraphType, GraphEffect GraphEffect, GraphData<T> GraphData) : base(GraphType, GraphEffect, GraphData)
        {
            this.createChart();
        }
        public override PlotModel createChart()
        {
            PlotModel model = new PlotModel { Title = base.graphData.graphTitle, TitleFontSize = 20 };
            /*
            var seriesP1 = new PieSeries { StrokeThickness = 2.0, InsideLabelPosition = 0.8, AngleSpan = 360, StartAngle = 0 };

            seriesP1.Slices.Add(new PieSlice("Africa", 1030) { IsExploded = false, Fill = OxyColors.PaleVioletRed });
            seriesP1.Slices.Add(new PieSlice("Americas", 929) { IsExploded = true });
            seriesP1.Slices.Add(new PieSlice("Asia", 4157) { IsExploded = true });
            seriesP1.Slices.Add(new PieSlice("Europe", 739) { IsExploded = true });
            seriesP1.Slices.Add(new PieSlice("Oceania", 35) { IsExploded = true });

            model.Series.Add(seriesP1);
            */
            return model;
        }
    }
    public class GraphFactory<T> : iGraphFactory<T>
    {
        Graph<T> Chart;
        public PlotModel createGraph(GraphType graphType, GraphEffect graphEffect, GraphData<T> graphData)
        {
            switch (graphType)
            {
                case GraphType.Line:
                    Chart = new LineChart<T>(graphType, graphEffect, graphData);
                    break;
                case GraphType.Pie:
                    Chart = new PieChart<T>(graphType, graphEffect, graphData);
                    break;
                default:
                    Chart = new BarChart<T>(graphType, graphEffect, graphData);
                    break;
            }
            return Chart.createChart();
        }
    }
}