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
using Android.Content;
using Android.Graphics;

using AChartEngine;
using AChartEngine.Charts;
using AChartEngine.Renderers;


namespace Sample.AChartEngine.Demo.Charts
{

	/// <summary>
	/// Scatter demo chart.
	/// </summary>
	public class ScatterChart : AbstractDemoChart
	{
	  /// <summary>
	  /// Returns the chart name.
	  /// </summary>
	  /// <returns> the chart name </returns>
	  public override string Name
	  {
		  get
		  {
			return "Scatter chart";
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
			return "Randomly generated values for the scatter chart";
		  }
	  }

	  /// <summary>
	  /// Executes the chart demo.
	  /// </summary>
	  /// <param name="context"> the context </param>
	  /// <returns> the built intent </returns>
	  public override Intent Execute(Context context)
	  {
		string[] titles = new string[] {"Series 1", "Series 2", "Series 3", "Series 4", "Series 5"};
		IList<double[]> x = new List<double[]>();
		IList<double[]> values = new List<double[]>();
		int count = 20;
		int length = titles.Length;
		Random r = new Random();
		for (int i = 0; i < length; i++)
		{
		  double[] xValues = new double[count];
		  double[] yValues = new double[count];
		  for (int k = 0; k < count; k++)
		  {
			xValues[k] = k + r.Next() % 10;
			yValues[k] = k * 2 + r.Next() % 10;
		  }
		  x.Add(xValues);
		  values.Add(yValues);
		}
		int[] colors = new int[] {Color.Blue, Color.Cyan, Color.Magenta, Color.LightGray, Color.Green};
		PointStyle[] styles = new PointStyle[] {PointStyle.X, PointStyle.Diamond, PointStyle.Triangle, PointStyle.Square, PointStyle.Circle};
		XYMultipleSeriesRenderer renderer = BuildRenderer(colors, styles);
		SetChartSettings(renderer, "Scatter chart", "X", "Y", -10, 30, -10, 51, Color.Gray, Color.LightGray);
		renderer.XLabels = 10;
		renderer.YLabels = 10;
		length = renderer.SeriesRendererCount;
		for (int i = 0; i < length; i++)
		{
		  ((XYSeriesRenderer) renderer.GetSeriesRendererAt(i)).FillPoints = true;
		}
		return ChartFactory.GetScatterChartIntent(context, BuildDataset(titles, x, values), renderer);
	  }

	}

}