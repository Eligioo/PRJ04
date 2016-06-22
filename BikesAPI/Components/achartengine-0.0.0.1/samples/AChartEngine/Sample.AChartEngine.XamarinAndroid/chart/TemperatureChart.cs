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
using AChartEngine.Models;
using AChartEngine.Renderers;

namespace Sample.AChartEngine.Demo.Charts
{

	/// <summary>
	/// Temperature demo range chart.
	/// </summary>
	public class TemperatureChart : AbstractDemoChart
	{

	  /// <summary>
	  /// Returns the chart name.
	  /// </summary>
	  /// <returns> the chart name </returns>
	  public override string Name
	  {
		  get
		  {
			return "Temperature range chart";
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
			return "The monthly temperature (vertical range chart)";
		  }
	  }

	  /// <summary>
	  /// Executes the chart demo.
	  /// </summary>
	  /// <param name="context"> the context </param>
	  /// <returns> the built intent </returns>
	  public override Intent Execute(Context context)
	  {
		double[] minValues = new double[] {-24, -19, -10, -1, 7, 12, 15, 14, 9, 1, -11, -16};
		double[] maxValues = new double[] {7, 12, 24, 28, 33, 35, 37, 36, 28, 19, 11, 4};

		XYMultipleSeriesDataset dataset = new XYMultipleSeriesDataset();
		RangeCategorySeries series = new RangeCategorySeries("Temperature");
		int length = minValues.Length;
		for (int k = 0; k < length; k++)
		{
		  series.Add(minValues[k], maxValues[k]);
		}
		dataset.AddSeries(series.ToXYSeries());
		int[] colors = new int[] {Color.Cyan};
		XYMultipleSeriesRenderer renderer = BuildBarRenderer(colors);
		SetChartSettings(renderer, "Monthly temperature range", "Month", "Celsius degrees", 0.5, 12.5, -30, 45, Color.Gray, Color.LightGray);
		renderer.BarSpacing = 0.5;
		renderer.XLabels = 0;
		renderer.YLabels = 10;
		renderer.AddXTextLabel(1, "Jan");
		renderer.AddXTextLabel(3, "Mar");
		renderer.AddXTextLabel(5, "May");
		renderer.AddXTextLabel(7, "Jul");
		renderer.AddXTextLabel(10, "Oct");
		renderer.AddXTextLabel(12, "Dec");
		renderer.AddYTextLabel(-25, "Very cold");
		renderer.AddYTextLabel(-10, "Cold");
		renderer.AddYTextLabel(5, "OK");
		renderer.AddYTextLabel(20, "Nice");
		renderer.SetMargins(new int[] {30, 70, 10, 0});
		renderer.SetYLabelsAlign(Android.Graphics.Paint.Align.Right);
		SimpleSeriesRenderer r = renderer.GetSeriesRendererAt(0);
		r.DisplayChartValues = true;
		r.ChartValuesTextSize = 12;
		r.ChartValuesSpacing = 3;
		r.GradientEnabled = true;
		r.SetGradientStart(-20, Color.Blue);
		r.SetGradientStop(20, Color.Green);
		return ChartFactory.GetRangeBarChartIntent(context, dataset, renderer, global::AChartEngine.Charts.BarChart.Type.Default, "Temperature range");
	  }

	}

}