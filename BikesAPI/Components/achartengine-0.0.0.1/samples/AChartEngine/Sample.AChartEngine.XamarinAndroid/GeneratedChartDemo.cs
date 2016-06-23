using System;
using System.Collections.Generic;

/// <summary>
/// Copyright (C) 2009 - 2013 SC 4ViewSoft SRL
///
/// Licensed under the Apache License, Version 2.0 (the "License");
/// you may not use this file except in compliance with the License.
/// You may obtain a copy of the License at
///
///      http://www.apache.org/licenses/LICENSE-2.0
///
/// Unless required by applicable law or agreed to in writing, software
/// distributed under the License is distributed on an "AS IS" BASIS,
/// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
/// See the License for the specific language governing permissions and
/// limitations under the License.
/// </summary>
using Android.App;
using Android.OS;
using Android.Widget;
using Android.Views;
using AChartEngine.Models;
using AChartEngine.Renderers;
using Android.Graphics;
using AChartEngine.Charts;
using AChartEngine;
using Android.Content;


namespace Sample.AChartEngine.Demo.Charts
{

    [Activity(Label = "GeneratedChartDemo")] 
    public class GeneratedChartDemo : ListActivity
    {
        private const int SERIES_NR = 2;

        private string[] mMenuText;

        private string[] mMenuSummary;

        /// <summary>
        /// Called when the activity is first created. </summary>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // I know, I know, this should go into strings.xml and accessed using
            // getString(R.string....)
            mMenuText = new string[] { "Line chart", "Scatter chart", "Time chart", "Bar chart" };
            mMenuSummary = new string[] { "Line chart with randomly generated values", "Scatter chart with randomly generated values", "Time chart with randomly generated values", "Bar chart with randomly generated values" };
            ListAdapter = new SimpleAdapter(this, ListValues, Android.Resource.Layout.SimpleExpandableListItem2, new string[] { Sample.AChartEngine.Demo.Charts.IDemoChart_Fields.NAME, Sample.AChartEngine.Demo.Charts.IDemoChart_Fields.DESC }, new int[] { Android.Resource.Id.Text1, Android.Resource.Id.Text2 });
        }

        // mono.android.runtime.JavaObject cannot be cast to java.util.Map
        //mc++ private IList<IDictionary<string, object>> ListValues
        private Android.Runtime.JavaList<IDictionary<string, object>> ListValues
        {
            get
            {
                Android.Runtime.JavaList<IDictionary<string, object>> values = null;
                values = new Android.Runtime.JavaList<IDictionary<string, object>>();
                int length = mMenuText.Length;
                for (int i = 0; i < length; i++)
                {
                    Android.Runtime.JavaDictionary<string, object> v = null;
                    v = new Android.Runtime.JavaDictionary<string, object>();
                    v[Sample.AChartEngine.Demo.Charts.IDemoChart_Fields.NAME] = mMenuText[i];
                    v[Sample.AChartEngine.Demo.Charts.IDemoChart_Fields.DESC] = mMenuSummary[i];
                    values.Add(v);
                }
                return values;
            }
        }

        private XYMultipleSeriesDataset DemoDataset
        {
            get
            {
                XYMultipleSeriesDataset dataset = new XYMultipleSeriesDataset();
                const int nr = 10;
                Random r = new Random();
                for (int i = 0; i < SERIES_NR; i++)
                {
                    XYSeries series = new XYSeries("Demo series " + (i + 1));
                    for (int k = 0; k < nr; k++)
                    {
                        series.Add(k, 20 + r.Next() % 100);
                    }
                    dataset.AddSeries(series);
                }
                return dataset;
            }
        }

        private XYMultipleSeriesDataset DateDemoDataset
        {
            get
            {
                XYMultipleSeriesDataset dataset = new XYMultipleSeriesDataset();
                const int nr = 10;
                long value = (DateTime.Now).Ticks - 3 * TimeChart.Day;
                Random r = new Random();
                for (int i = 0; i < SERIES_NR; i++)
                {
                    TimeSeries series = new TimeSeries("Demo series " + (i + 1));
                    for (int k = 0; k < nr; k++)
                    {
                        series.Add(new Java.Util.Date(value + k * TimeChart.Day / 4), 20 + r.Next() % 100);
                    }
                    dataset.AddSeries(series);
                }
                return dataset;
            }
        }

        private XYMultipleSeriesDataset BarDemoDataset
        {
            get
            {
                XYMultipleSeriesDataset dataset = new XYMultipleSeriesDataset();
                const int nr = 10;
                Random r = new Random();
                for (int i = 0; i < SERIES_NR; i++)
                {
                    CategorySeries series = new CategorySeries("Demo series " + (i + 1));
                    for (int k = 0; k < nr; k++)
                    {
                        series.Add(100 + r.Next() % 100);
                    }
                    dataset.AddSeries(series.ToXYSeries());
                }
                return dataset;
            }
        }

        private XYMultipleSeriesRenderer DemoRenderer
        {
            get
            {
                XYMultipleSeriesRenderer renderer = new XYMultipleSeriesRenderer();
                renderer.AxisTitleTextSize = 16;
                renderer.ChartTitleTextSize = 20;
                renderer.LabelsTextSize = 15;
                renderer.LegendTextSize = 15;
                renderer.PointSize = 5f;
                renderer.SetMargins(new int[] { 20, 30, 15, 0 });
                XYSeriesRenderer r = new XYSeriesRenderer();
                r.Color = Color.Blue;
                r.PointStyle = PointStyle.Square;
                r.FillBelowLine = true;
                r.SetFillBelowLineColor(Color.White);
                r.FillPoints = true;
                renderer.AddSeriesRenderer(r);
                r = new XYSeriesRenderer();
                r.PointStyle = PointStyle.Circle;
                r.Color = Color.Green;
                r.FillPoints = true;
                renderer.AddSeriesRenderer(r);
                renderer.AxesColor = Color.DarkGray;
                renderer.LabelsColor = Color.LightGray;
                return renderer;
            }
        }

        public virtual XYMultipleSeriesRenderer BarDemoRenderer
        {
            get
            {
                XYMultipleSeriesRenderer renderer = new XYMultipleSeriesRenderer();
                renderer.AxisTitleTextSize = 16;
                renderer.ChartTitleTextSize = 20;
                renderer.LabelsTextSize = 15;
                renderer.LegendTextSize = 15;
                renderer.SetMargins(new int[] { 20, 30, 15, 0 });
                SimpleSeriesRenderer r = new SimpleSeriesRenderer();
                r.Color = Color.Blue;
                renderer.AddSeriesRenderer(r);
                r = new SimpleSeriesRenderer();
                r.Color = Color.Green;
                renderer.AddSeriesRenderer(r);
                return renderer;
            }
        }

        private XYMultipleSeriesRenderer ChartSettings
        {
            set
            {
                value.ChartTitle = "Chart demo";
                value.XTitle = "x values";
                value.YTitle = "y values";
                value.XAxisMin = 0.5;
                value.XAxisMax = 10.5;
                value.YAxisMin = 0;
                value.YAxisMax = 210;
            }
        }

        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            base.OnListItemClick(l, v, position, id);
            switch (position)
            {
                case 0:
                    Intent intent = ChartFactory.GetLineChartIntent(this, DemoDataset, DemoRenderer);
                    StartActivity(intent);
                    break;
                case 1:
                    intent = ChartFactory.GetScatterChartIntent(this, DemoDataset, DemoRenderer);
                    StartActivity(intent);
                    break;
                case 2:
                    intent = ChartFactory.GetTimeChartIntent(this, DateDemoDataset, DemoRenderer, null);
                    StartActivity(intent);
                    break;
                case 3:
                    XYMultipleSeriesRenderer renderer = BarDemoRenderer;
                    ChartSettings = renderer;
                    intent = ChartFactory.GetBarChartIntent(this, BarDemoDataset, renderer, BarChart.Type.Default);
                    StartActivity(intent);
                    break;
            }
        }
    }
}