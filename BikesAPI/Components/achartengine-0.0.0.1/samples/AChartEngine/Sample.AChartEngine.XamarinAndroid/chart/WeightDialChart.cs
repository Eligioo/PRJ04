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
	/// Budget demo pie chart.
	/// </summary>
	public class WeightDialChart : AbstractDemoChart
	{
	  /// <summary>
	  /// Returns the chart name. </summary>
	  /// <returns> the chart name </returns>
	  public override string Name
	  {
		  get
		  {
			return "Weight chart";
		  }
	  }

	  /// <summary>
	  /// Returns the chart description. </summary>
	  /// <returns> the chart description </returns>
	  public override string Desc
	  {
		  get
		  {
			return "The weight indicator (dial chart)";
		  }
	  }

	  /// <summary>
	  /// Executes the chart demo. </summary>
	  /// <param name="context"> the context </param>
	  /// <returns> the built intent </returns>
	  public override Intent Execute(Context context)
	  {
		CategorySeries category = new CategorySeries("Weight indic");
		category.Add("Current", 75);
		category.Add("Minimum", 65);
		category.Add("Maximum", 90);
		DialRenderer renderer = new DialRenderer();
		renderer.ChartTitleTextSize = 20;
		renderer.LabelsTextSize = 15;
		renderer.LegendTextSize = 15;
		renderer.SetMargins(new int[] {20, 30, 15, 0});
		SimpleSeriesRenderer r = new SimpleSeriesRenderer();
		r.Color = Color.Blue;
		renderer.AddSeriesRenderer(r);
		r = new SimpleSeriesRenderer();
		r.Color = Color.Rgb(0, 150, 0);
		renderer.AddSeriesRenderer(r);
		r = new SimpleSeriesRenderer();
		r.Color = Color.Green;
		renderer.AddSeriesRenderer(r);
		renderer.LabelsTextSize = 10;
		renderer.LabelsColor = Color.White;
		renderer.ShowLabels = true;
		renderer.SetVisualTypes(new DialRenderer.Type[] {DialRenderer.Type.Arrow, DialRenderer.Type.Needle, DialRenderer.Type.Needle});
		renderer.MinValue = 0;
		renderer.MaxValue = 150;
		return ChartFactory.GetDialChartIntent(context, category, renderer, "Weight indicator");
	  }

	}

}