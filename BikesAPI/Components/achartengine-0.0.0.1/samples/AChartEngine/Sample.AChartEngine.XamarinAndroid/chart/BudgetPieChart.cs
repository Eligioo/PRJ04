﻿/// <summary>
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
	/// Budget demo pie chart.
	/// </summary>
	public class BudgetPieChart : AbstractDemoChart
	{
	  /// <summary>
	  /// Returns the chart name.
	  /// </summary>
	  /// <returns> the chart name </returns>
	  public override string Name
	  {
		  get
		  {
			return "Budget chart";
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
			return "The budget per project for this year (pie chart)";
		  }
	  }

	  /// <summary>
	  /// Executes the chart demo.
	  /// </summary>
	  /// <param name="context"> the context </param>
	  /// <returns> the built intent </returns>
	  public override Intent Execute(Context context)
	  {
		double[] values = new double[] {12, 14, 11, 10, 19};
		int[] colors = new int[] {Color.Blue, Color.Green, Color.Magenta,  Color.Yellow, Color.Cyan};
		DefaultRenderer renderer = BuildCategoryRenderer(colors);
		renderer.ZoomButtonsVisible = true;
		renderer.ZoomEnabled = true;
		renderer.ChartTitleTextSize = 20;
		renderer.DisplayValues = true;
		renderer.ShowLabels = false;
		SimpleSeriesRenderer r = renderer.GetSeriesRendererAt(0);
		r.GradientEnabled = true;
		r.SetGradientStart(0, Color.Blue);
		r.SetGradientStop(0, Color.Green);
		r.Highlighted = true;
		Intent intent = ChartFactory.GetPieChartIntent(context, BuildCategoryDataset("Project budget", values), renderer, "Budget");
		return intent;
	  }

	}

}