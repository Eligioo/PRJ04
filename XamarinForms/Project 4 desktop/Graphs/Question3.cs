using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeDataModels;
using OxyPlot.Series;
using OxyPlot.Axes;

namespace Project_4_desktop.Graphs
{
    public class Question3 : PlotModel
    {

        public Question3()
        {
            var picker = new Question3NeighborhoodPicker(this);
            picker.Show();
            var valueAxis = new LinearAxis
            {
                Position = AxisPosition.Bottom,
                MinimumPadding = 0,
                MaximumPadding = 0.06,
                AbsoluteMinimum = 0
            };
            var categoryAxis = new CategoryAxis
            {
                Position = AxisPosition.Left,
                AbsoluteMinimum = 0,
                AbsoluteMaximum = 96
            };
            for (int i = 96; i > 0; i--)
            {
                if (i % 2 == 0)
                {
                    int o = (int)Math.Ceiling((float)i / 2);
                    categoryAxis.Labels.Add(((o + 5) % 12 + 1).ToString() + " - " + (((int)(Math.Floor((float)o + 5) / 12) + 2009).ToString()));
                }
                else
                {
                    categoryAxis.Labels.Add("");
                }
            }
            Axes.Add(categoryAxis);
            Axes.Add(valueAxis);
        }
        internal void RefreshData(CombinationofTheftTrommelAreaMonth input)
        {
            var trommelBars = new BarSeries
            {
                Title = "Hoeveelheid trommels",
                FillColor = OxyColor.FromRgb((byte)0, (byte)0, (byte)255),
                StrokeColor = OxyColors.Blue,
                StrokeThickness = 1
            };
            var theftBars = new BarSeries
            {
                Title = "Hoeveelheid diefstallen",
                FillColor = OxyColor.FromRgb((byte)255, (byte)0, (byte)0),
                StrokeColor = OxyColors.Red,
                StrokeThickness = 1
            };
            for (int i = 0; i < 48; i++)
            {
                if (input.Rows.Count() > i)
                {
                    theftBars.Items.Add(new BarItem { Value = input.Rows.ElementAt(i).Thefts, Color = OxyPlot.OxyColor.FromRgb((byte)255, (byte)0, (byte)0) });
                    theftBars.Items.Add(new BarItem { Value = 0 });
                }else
                {
                    theftBars.Items.Add(new BarItem { Value = 0 });
                    theftBars.Items.Add(new BarItem { Value = 0 });
                }
                if (input.Rows.Count() > i)
                {
                    trommelBars.Items.Add(new BarItem { Value = 0 });
                    trommelBars.Items.Add(new BarItem { Value = input.Rows.ElementAt(i).Trommels, Color = OxyPlot.OxyColor.FromRgb((byte)0, (byte)0, (byte)255) });
                }
                else
                {
                    trommelBars.Items.Add(new BarItem { Value = 0 });
                    trommelBars.Items.Add(new BarItem { Value = 0 });
                }
            }
            Series.Clear();
            Series.Add(theftBars);
            Series.Add(trommelBars);
            InvalidatePlot(true);
        }
    }
}
