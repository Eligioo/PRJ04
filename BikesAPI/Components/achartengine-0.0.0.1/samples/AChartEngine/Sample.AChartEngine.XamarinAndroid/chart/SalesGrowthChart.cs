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

using AChartEngine;
using AChartEngine.Charts;
using AChartEngine.Renderers;
using Android.Graphics;


namespace Sample.AChartEngine.Demo.Charts
{

	/// <summary>
	/// Sales growth demo chart.
	/// </summary>
	public class SalesGrowthChart : AbstractDemoChart
	{
	  /// <summary>
	  /// Returns the chart name.
	  /// </summary>
	  /// <returns> the chart name </returns>
	  public override string Name
	  {
		  get
		  {
			return "Sales growth";
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
			return "The sales growth across several years (time chart)";
		  }
	  }

	  /// <summary>
	  /// Executes the chart demo.
	  /// </summary>
	  /// <param name="context"> the context </param>
	  /// <returns> the built intent </returns>
	  public override Intent Execute(Context context)
	  {
		string[] titles = new string[] {"Sales growth January 1995 to December 2000"};
			IList<Java.Util.Date[]> dates = new List<Java.Util.Date[]>();
		IList<double[]> values = new List<double[]>();
			Java.Util.Date[] dateValues = new Java.Util.Date[]
		{
				new Java.Util.Date(95, 0, 1),
				new Java.Util.Date(95, 3, 1),
				new Java.Util.Date(95, 6, 1),
				new Java.Util.Date(95, 9, 1),
				new Java.Util.Date(96, 0, 1),
				new Java.Util.Date(96, 3, 1),
				new Java.Util.Date(96, 6, 1),
				new Java.Util.Date(96, 9, 1),
				new Java.Util.Date(97, 0, 1),
				new Java.Util.Date(97, 3, 1),
				new Java.Util.Date(97, 6, 1),
				new Java.Util.Date(97, 9, 1),
				new Java.Util.Date(98, 0, 1),
				new Java.Util.Date(98, 3, 1),
				new Java.Util.Date(98, 6, 1),
				new Java.Util.Date(98, 9, 1),
				new Java.Util.Date(99, 0, 1),
				new Java.Util.Date(99, 3, 1),
				new Java.Util.Date(99, 6, 1),
				new Java.Util.Date(99, 9, 1),
				new Java.Util.Date(100, 0, 1),
				new Java.Util.Date(100, 3, 1),
				new Java.Util.Date(100, 6, 1),
				new Java.Util.Date(100, 9, 1),
				new Java.Util.Date(100, 11, 1)
		};
		dates.Add(dateValues);

		values.Add(new double[] {4.9, 5.3, 3.2, 4.5, 6.5, 4.7, 5.8, 4.3, 4, 2.3, -0.5, -2.9, 3.2, 5.5, 4.6, 9.4, 4.3, 1.2, 0, 0.4, 4.5, 3.4, 4.5, 4.3, 4});
		int[] colors = new int[] {Color.Blue};
		PointStyle[] styles = new PointStyle[] {PointStyle.Point};
		XYMultipleSeriesRenderer renderer = BuildRenderer(colors, styles);
		SetChartSettings(renderer, "Sales growth", "Date", "%", dateValues[0].Time, dateValues[dateValues.Length - 1].Time, -4, 11, Color.Gray, Color.LightGray);
		renderer.YLabels = 10;
		renderer.XRoundedLabels = false;
		XYSeriesRenderer xyRenderer = (XYSeriesRenderer) renderer.GetSeriesRendererAt(0);
		XYSeriesRenderer.FillOutsideLine fill = new XYSeriesRenderer.FillOutsideLine(XYSeriesRenderer.FillOutsideLine.FillOutsideLineType.BoundsAbove);
		fill.Color = Color.Green;
		xyRenderer.AddFillOutsideLine(fill);
			fill = new XYSeriesRenderer.FillOutsideLine(XYSeriesRenderer.FillOutsideLine.FillOutsideLineType.BoundsBelow);
		fill.Color = Color.Magenta;
		xyRenderer.AddFillOutsideLine(fill);
			fill = new XYSeriesRenderer.FillOutsideLine(XYSeriesRenderer.FillOutsideLine.FillOutsideLineType.BoundsAbove);
		fill.Color = Color.Argb(255, 0, 200, 100);
		fill.SetFillRange(new int[] {10, 19});
		xyRenderer.AddFillOutsideLine(fill);

		return ChartFactory.GetTimeChartIntent(context, BuildDateDataset(titles, dates, values), renderer, "MMM yyyy");
	  }

	}

}