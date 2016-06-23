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
	/// Multiple temperature demo chart.
	/// </summary>
	public class MultipleTemperatureChart : AbstractDemoChart
	{
	  /// <summary>
	  /// Returns the chart name.
	  /// </summary>
	  /// <returns> the chart name </returns>
	  public override string Name
	  {
		  get
		  {
			return "Temperature and sunshine";
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
			return "The average temperature and hours of sunshine in Crete (line chart with multiple Y scales and axis)";
		  }
	  }

	  /// <summary>
	  /// Executes the chart demo.
	  /// </summary>
	  /// <param name="context"> the context </param>
	  /// <returns> the built intent </returns>
	  public override Intent Execute(Context context)
	  {
		string[] titles = new string[] {"Air temperature"};
		IList<double[]> x = new List<double[]>();
		for (int i = 0; i < titles.Length; i++)
		{
		  x.Add(new double[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12});
		}
		IList<double[]> values = new List<double[]>();
		values.Add(new double[] {12.3, 12.5, 13.8, 16.8, 20.4, 24.4, 26.4, 26.1, 23.6, 20.3, 17.2, 13.9});
		int[] colors = new int[] {Color.Blue,  Color.Yellow};
		PointStyle[] styles = new PointStyle[] {PointStyle.Point, PointStyle.Point};
		XYMultipleSeriesRenderer renderer = new XYMultipleSeriesRenderer(2);
		SetRenderer(renderer, colors, styles);
		int length = renderer.SeriesRendererCount;
		for (int i = 0; i < length; i++)
		{
		  XYSeriesRenderer r = (XYSeriesRenderer) renderer.GetSeriesRendererAt(i);
		  r.LineWidth = 3f;
		}
		SetChartSettings(renderer, "Average temperature", "Month", "Temperature", 0.5, 12.5, 0, 32, Color.LightGray, Color.LightGray);
		renderer.XLabels = 12;
		renderer.YLabels = 10;
		renderer.SetShowGrid(true);
		renderer.XLabelsAlign = Android.Graphics.Paint.Align.Right;
		renderer.SetYLabelsAlign(Android.Graphics.Paint.Align.Right);
		renderer.ZoomButtonsVisible = true;
		renderer.SetPanLimits(new double[] {-10, 20, -10, 40});
		renderer.SetZoomLimits(new double[] {-10, 20, -10, 40});
		renderer.ZoomRate = 1.05f;
		renderer.LabelsColor = Color.White;
		renderer.XLabelsColor = Color.Green;
		renderer.SetYLabelsColor(0, colors[0]);
		renderer.SetYLabelsColor(1, colors[1]);

		renderer.SetYTitle("Hours", 1);
		renderer.SetYAxisAlign(Android.Graphics.Paint.Align.Right, 1);
		renderer.SetYLabelsAlign(Android.Graphics.Paint.Align.Left, 1);

		XYMultipleSeriesDataset dataset = BuildDataset(titles, x, values);
		values.Clear();
		values.Add(new double[] {4.3, 4.9, 5.9, 8.8, 10.8, 11.9, 13.6, 12.8, 11.4, 9.5, 7.5, 5.5});
		AddXYSeries(dataset, new string[] {"Sunshine hours"}, x, values, 1);

		Intent intent = ChartFactory.GetCubicLineChartIntent(context, dataset, renderer, 0.3f, "Average temperature");
		return intent;
	  }
	}

}