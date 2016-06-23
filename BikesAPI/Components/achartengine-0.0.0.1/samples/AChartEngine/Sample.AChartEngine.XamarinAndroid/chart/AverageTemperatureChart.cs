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
	/// Average temperature demo chart.
	/// </summary>
	public class AverageTemperatureChart : AbstractDemoChart
	{
	  /// <summary>
	  /// Returns the chart name.
	  /// </summary>
	  /// <returns> the chart name </returns>
	  public override string Name
	  {
		  get
		  {
			return "Average temperature";
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
			return "The average temperature in 4 Greek islands (line chart)";
		  }
	  }

	  /// <summary>
	  /// Executes the chart demo.
	  /// </summary>
	  /// <param name="context"> the context </param>
	  /// <returns> the built intent </returns>
	  public override Intent Execute(Context context)
	  {
		string[] titles = new string[] {"Crete", "Corfu", "Thassos", "Skiathos"};
		IList<double[]> x = new List<double[]>();
		for (int i = 0; i < titles.Length; i++)
		{
		  x.Add(new double[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12});
		}
		IList<double[]> values = new List<double[]>();
		values.Add(new double[] {12.3, 12.5, 13.8, 16.8, 20.4, 24.4, 26.4, 26.1, 23.6, 20.3, 17.2, 13.9});
		values.Add(new double[] {10, 10, 12, 15, 20, 24, 26, 26, 23, 18, 14, 11});
		values.Add(new double[] {5, 5.3, 8, 12, 17, 22, 24.2, 24, 19, 15, 9, 6});
		values.Add(new double[] {9, 10, 11, 15, 19, 23, 26, 25, 22, 18, 13, 10});
		int[] colors = new int[] {Color.Blue, Color.Green, Color.Cyan,  Color.Yellow};
		PointStyle[] styles = new PointStyle[] {PointStyle.Circle, PointStyle.Diamond, PointStyle.Triangle, PointStyle.Square};
		XYMultipleSeriesRenderer renderer = BuildRenderer(colors, styles);
		int length = renderer.SeriesRendererCount;
		for (int i = 0; i < length; i++)
		{
		  ((XYSeriesRenderer) renderer.GetSeriesRendererAt(i)).FillPoints = true;
		}
		SetChartSettings(renderer, "Average temperature", "Month", "Temperature", 0.5, 12.5, -10, 40, Color.LightGray, Color.LightGray);
		renderer.XLabels = 12;
		renderer.YLabels = 10;
		renderer.SetShowGrid(true);
		renderer.XLabelsAlign = Android.Graphics.Paint.Align.Right;
		renderer.SetYLabelsAlign(Android.Graphics.Paint.Align.Right);
		renderer.ZoomButtonsVisible = true;
		renderer.SetPanLimits(new double[] {-10, 20, -10, 40});
		renderer.SetZoomLimits(new double[] {-10, 20, -10, 40});

		XYMultipleSeriesDataset dataset = BuildDataset(titles, x, values);
		XYSeries series = dataset.GetSeriesAt(0);
		series.AddAnnotation("Vacation", 6, 30);
		Intent intent = ChartFactory.GetLineChartIntent(context, dataset, renderer, "Average temperature");
		return intent;
	  }

	}

}