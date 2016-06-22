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
using Android.Content;
using Android.Graphics;

using AChartEngine;
using AChartEngine.Charts;
using AChartEngine.Models;
using AChartEngine.Renderers;

namespace Sample.AChartEngine.Demo.Charts
{

	/// <summary>
	/// Combined temperature demo chart.
	/// </summary>
	public class CombinedTemperatureChart : AbstractDemoChart
	{
	  /// <summary>
	  /// Returns the chart name.
	  /// </summary>
	  /// <returns> the chart name </returns>
	  public override string Name
	  {
		  get
		  {
			return "Combined temperature";
		  }
	  }

	  /// <summary>
	  /// Returns the chart description.
	  /// </summary>
	  /// <returns> the chart description </returns>
	  public override string Desc
	  {
		  get
		  {
			return "The average temperature in 2 Greek islands, water temperature and sun shine hours (combined chart)";
		  }
	  }

	  /// <summary>
	  /// Executes the chart demo.
	  /// </summary>
	  /// <param name="context"> the context </param>
	  /// <returns> the built intent </returns>
	  public override Intent Execute(Context context)
	  {
		string[] titles = new string[] {"Crete Air Temperature", "Skiathos Air Temperature"};
		IList<double[]> x = new List<double[]>();
		for (int i = 0; i < titles.Length; i++)
		{
		  x.Add(new double[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12});
		}
		IList<double[]> values = new List<double[]>();
		values.Add(new double[] {12.3, 12.5, 13.8, 16.8, 20.4, 24.4, 26.4, 26.1, 23.6, 20.3, 17.2, 13.9});
		values.Add(new double[] {9, 10, 11, 15, 19, 23, 26, 25, 22, 18, 13, 10});
		int[] colors = new int[] {Color.Green, Color.Rgb(200, 150, 0)};
		PointStyle[] styles = new PointStyle[] {PointStyle.Circle, PointStyle.Diamond};
		XYMultipleSeriesRenderer renderer = BuildRenderer(colors, styles);
		renderer.PointSize = 5.5f;
		int length = renderer.SeriesRendererCount;
		for (int i = 0; i < length; i++)
		{
		  XYSeriesRenderer r = (XYSeriesRenderer) renderer.GetSeriesRendererAt(i);
		  r.LineWidth = 5;
		  r.FillPoints = true;
		}
		SetChartSettings(renderer, "Weather data", "Month", "Temperature", 0.5, 12.5, 0, 40, Color.LightGray, Color.LightGray);

		renderer.XLabels = 12;
		renderer.YLabels = 10;
		renderer.SetShowGrid(true);
		renderer.XLabelsAlign = Android.Graphics.Paint.Align.Right;
		renderer.SetYLabelsAlign(Android.Graphics.Paint.Align.Right);
		renderer.ZoomButtonsVisible = true;
		renderer.SetPanLimits(new double[] {-10, 20, -10, 40});
		renderer.SetZoomLimits(new double[] {-10, 20, -10, 40});

		XYValueSeries sunSeries = new XYValueSeries("Sunshine hours");
		sunSeries.Add(1f, 35, 4.3);
		sunSeries.Add(2f, 35, 4.9);
		sunSeries.Add(3f, 35, 5.9);
		sunSeries.Add(4f, 35, 8.8);
		sunSeries.Add(5f, 35, 10.8);
		sunSeries.Add(6f, 35, 11.9);
		sunSeries.Add(7f, 35, 13.6);
		sunSeries.Add(8f, 35, 12.8);
		sunSeries.Add(9f, 35, 11.4);
		sunSeries.Add(10f, 35, 9.5);
		sunSeries.Add(11f, 35, 7.5);
		sunSeries.Add(12f, 35, 5.5);
		XYSeriesRenderer lightRenderer = new XYSeriesRenderer();
		lightRenderer.Color =  Color.Yellow;

		XYSeries waterSeries = new XYSeries("Water Temperature");
		waterSeries.Add(1, 16);
		waterSeries.Add(2, 15);
		waterSeries.Add(3, 16);
		waterSeries.Add(4, 17);
		waterSeries.Add(5, 20);
		waterSeries.Add(6, 23);
		waterSeries.Add(7, 25);
		waterSeries.Add(8, 25.5);
		waterSeries.Add(9, 26.5);
		waterSeries.Add(10, 24);
		waterSeries.Add(11, 22);
		waterSeries.Add(12, 18);
		renderer.BarSpacing = 0.5;
		XYSeriesRenderer waterRenderer = new XYSeriesRenderer();
		waterRenderer.Color = Color.Argb(250, 0, 210, 250);

		XYMultipleSeriesDataset dataset = BuildDataset(titles, x, values);
		dataset.AddSeries(0, sunSeries);
		dataset.AddSeries(0, waterSeries);
		renderer.AddSeriesRenderer(0, lightRenderer);
		renderer.AddSeriesRenderer(0, waterRenderer);
		waterRenderer.DisplayChartValues = true;
		waterRenderer.ChartValuesTextSize = 10;

			string[] types = new string[] 
            {
                //BarChart.Type.Default.ToString(), 
                "Bar",
                BubbleChart.Type.ToString(), 
                LineChart.Type.ToString(), 
                CubicLineChart.Type.ToString()
            };
		Intent intent = ChartFactory.GetCombinedXYChartIntent(context, dataset, renderer, types, "Weather parameters");
		return intent;
	  }

	}

}