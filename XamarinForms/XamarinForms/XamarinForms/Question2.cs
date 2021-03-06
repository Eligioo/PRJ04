﻿using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.Xamarin.Forms;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using XamarinForms.Graphs;
using Newtonsoft.Json;
using BikeDataModels;
using System.Net.Http;
using Android.Util;
using Project4;

namespace XamarinForms
{
    public class Question2 : QuestionLoadPage<List<StolenBikeInMonthOfYear>>
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public Question2() : base("questions/q2")
        {
            Title = "    gestolen fietsen per maand";
        }
        protected override void OnCacheLoaded()
        {
            var BikeTheftList = new List<Tuple<int, int, int>>();
            foreach (var item in Cache)
            {
                BikeTheftList.Add(new Tuple<int, int, int>(item.StolenBikes, item.Month, item.Year));
            }
            var graphData = new GraphData<int>("Hoeveelheid fietsdiefstallen per maand",
                "Trommels", "maand", new List<int>());
            GraphFactory<int> graphFactory = new GraphFactory<int>();
            PlotModel plotModel = graphFactory.createGraph(GraphType.Line, new GraphEffect(), graphData);
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
                AbsoluteMaximum = 2014
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
            plotModel.Series.Add(points);
            plotModel.Axes.Add(valueAxis);
            plotModel.Axes.Add(categoryAxis);
            this.Content = new PlotView
            {
                BackgroundColor = Device.OnPlatform<Color>(Color.Default, Color.White, Color.Default),
                Model = plotModel
            };
        }
    }
}