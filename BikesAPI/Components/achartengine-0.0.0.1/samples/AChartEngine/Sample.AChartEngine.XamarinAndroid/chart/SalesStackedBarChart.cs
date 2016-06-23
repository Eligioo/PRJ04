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
using AChartEngine.Renderers;


namespace Sample.AChartEngine.Demo.Charts
{

	/// <summary>
	/// Sales demo bar chart.
	/// </summary>
	public class SalesStackedBarChart : AbstractDemoChart
	{
	  /// <summary>
	  /// Returns the chart name.
	  /// </summary>
	  /// <returns> the chart name </returns>
	  public override string Name
	  {
		  get
		  {
			return "Sales stacked bar chart";
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
			return "The monthly sales for the last 2 years (stacked bar chart)";
		  }
	  }

	  /// <summary>
	  /// Executes the chart demo.
	  /// </summary>
	  /// <param name="context"> the context </param>
	  /// <returns> the built intent </returns>
	  public override Intent Execute(Context context)
	  {
		string[] titles = new string[] {"2008", "2007"};
		IList<double[]> values = new List<double[]>();
		values.Add(new double[] {14230, 12300, 14240, 15244, 15900, 19200, 22030, 21200, 19500, 15500, 12600, 14000});
		values.Add(new double[] {5230, 7300, 9240, 10540, 7900, 9200, 12030, 11200, 9500, 10500, 11600, 13500});
		int[] colors = new int[] {Color.Blue, Color.Cyan};
		XYMultipleSeriesRenderer renderer = BuildBarRenderer(colors);
		SetChartSettings(renderer, "Monthly sales in the last 2 years", "Month", "Units sold", 0.5, 12.5, 0, 24000, Color.Gray, Color.LightGray);
		renderer.GetSeriesRendererAt(0).DisplayChartValues = true;
		renderer.GetSeriesRendererAt(1).DisplayChartValues = true;
		renderer.XLabels = 12;
		renderer.YLabels = 10;
		renderer.XLabelsAlign = Android.Graphics.Paint.Align.Left;
		renderer.SetYLabelsAlign(Android.Graphics.Paint.Align.Left);
		renderer.SetPanEnabled(true, false);
		// renderer.SetZoomEnabled(false);
		renderer.ZoomRate = 1.1f;
		renderer.BarSpacing = 0.5f;
		return ChartFactory.GetBarChartIntent(context, BuildBarDataset(titles, values), renderer, global::AChartEngine.Charts.BarChart.Type.Stacked);
	  }

	}

}