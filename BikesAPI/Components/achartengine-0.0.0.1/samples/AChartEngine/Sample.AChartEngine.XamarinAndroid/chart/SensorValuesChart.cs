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
using AChartEngine.Utils;


namespace Sample.AChartEngine.Demo.Charts
{

	/// <summary>
	/// Temperature sensor demo chart.
	/// </summary>
	public class SensorValuesChart : AbstractDemoChart
	{
	  private const long HOUR = 3600 * 1000;

	  private static readonly long DAY = HOUR * 24;

	  private const int HOURS = 24;

	  /// <summary>
	  /// Returns the chart name.
	  /// </summary>
	  /// <returns> the chart name </returns>
	  public override string Name
	  {
		  get
		  {
			return "Sensor data";
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
			return "The temperature, as read from an outside and an inside sensors";
		  }
	  }

	  /// <summary>
	  /// Executes the chart demo.
	  /// </summary>
	  /// <param name="context"> the context </param>
	  /// <returns> the built intent </returns>
	  public override Intent Execute(Context context)
	  {
		string[] titles = new string[] {"Inside", "Outside"};
		long now = (long) Math.Round((decimal) DateTime.Now.Ticks / DAY) * DAY;
		IList<Java.Util.Date[]> x = new List<Java.Util.Date[]>();
		for (int i = 0; i < titles.Length; i++)
		{
		  Java.Util.Date[] dates = new Java.Util.Date[HOURS];
		  for (int j = 0; j < HOURS; j++)
		  {
			dates[j] = new Java.Util.Date(now - (HOURS - j) * HOUR);
		  }
		  x.Add(dates);
		}
		IList<double[]> values = new List<double[]>();

		values.Add(new double[] {21.2, 21.5, 21.7, 21.5, 21.4, 21.4, 21.3, 21.1, 20.6, 20.3, 20.2, 19.9, 19.7, 19.6, 19.9, 20.3, 20.6, 20.9, 21.2, 21.6, 21.9, 22.1, 21.7, 21.5});
		values.Add(new double[] {1.9, 1.2, 0.9, 0.5, 0.1, -0.5, -0.6, MathHelper.NullValue, MathHelper.NullValue, -1.8, -0.3, 1.4, 3.4, 4.9, 7.0, 6.4, 3.4, 2.0, 1.5, 0.9, -0.5, MathHelper.NullValue, -1.9, -2.5, -4.3});

		int[] colors = new int[] {Color.Green, Color.Blue};
		PointStyle[] styles = new PointStyle[] {PointStyle.Circle, PointStyle.Diamond};
		XYMultipleSeriesRenderer renderer = BuildRenderer(colors, styles);
		int length = renderer.SeriesRendererCount;
		for (int i = 0; i < length; i++)
		{
		  ((XYSeriesRenderer) renderer.GetSeriesRendererAt(i)).FillPoints = true;
		}
		SetChartSettings(renderer, "Sensor temperature", "Hour", "Celsius degrees", x[0][0].Time, x[0][HOURS - 1].Time, -5, 30, Color.LightGray, Color.LightGray);
		renderer.XLabels = 10;
		renderer.YLabels = 10;
		renderer.SetShowGrid(true);
		renderer.XLabelsAlign = Android.Graphics.Paint.Align.Center;
		renderer.SetYLabelsAlign(Android.Graphics.Paint.Align.Right);
		Intent intent = ChartFactory.GetTimeChartIntent(context, BuildDateDataset(titles, x, values), renderer, "h:mm a");
		return intent;
	  }

	}

}