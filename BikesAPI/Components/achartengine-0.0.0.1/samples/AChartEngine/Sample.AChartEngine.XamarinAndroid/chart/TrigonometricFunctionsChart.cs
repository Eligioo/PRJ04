﻿using System;
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
	/// Trigonometric functions demo chart.
	/// </summary>
	public class TrigonometricFunctionsChart : AbstractDemoChart
	{
	  /// <summary>
	  /// Returns the chart name. </summary>
	  /// <returns> the chart name </returns>
	  public override string Name
	  {
		  get
		  {
			return "Trigonometric functions";
		  }
	  }

	  /// <summary>
	  /// Returns the chart description. </summary>
	  /// <returns> the chart description </returns>
	  public override string Desc
	  {
		  get
		  {
			return "The graphical representations of the sin and cos functions (line chart)";
		  }
	  }

	  /// <summary>
	  /// Executes the chart demo. </summary>
	  /// <param name="context"> the context </param>
	  /// <returns> the built intent </returns>
	  public override Intent Execute(Context context)
	  {
		string[] titles = new string[] {"sin", "cos"};
		IList<double[]> x = new List<double[]>();
		IList<double[]> values = new List<double[]>();
		int step = 4;
		int count = 360 / step + 1;
		x.Add(new double[count]);
		x.Add(new double[count]);
		double[] sinValues = new double[count];
		double[] cosValues = new double[count];
		values.Add(sinValues);
		values.Add(cosValues);
		for (int i = 0; i < count; i++)
		{
		  int angle = i * step;
		  x[0][i] = angle;
		  x[1][i] = angle;
		  double rAngle = Java.Lang.Math.ToRadians(angle);
		  sinValues[i] = Math.Sin(rAngle);
		  cosValues[i] = Math.Cos(rAngle);
		}
		int[] colors = new int[] {Color.Blue, Color.Cyan};
		PointStyle[] styles = new PointStyle[] {PointStyle.Point, PointStyle.Point};
		XYMultipleSeriesRenderer renderer = BuildRenderer(colors, styles);
		SetChartSettings(renderer, "Trigonometric functions", "X (in degrees)", "Y", 0, 360, -1, 1, Color.Gray, Color.LightGray);
		renderer.XLabels = 20;
		renderer.YLabels = 10;
		return ChartFactory.GetLineChartIntent(context, BuildDataset(titles, x, values), renderer);
	  }

	}

}