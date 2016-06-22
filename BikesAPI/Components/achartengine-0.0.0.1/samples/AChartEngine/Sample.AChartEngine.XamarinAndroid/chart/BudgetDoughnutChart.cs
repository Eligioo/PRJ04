﻿using System.Collections.Generic;

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
using Android.Graphics;
using AChartEngine.Renderers;


namespace Sample.AChartEngine.Demo.Charts
{

	/// <summary>
	/// Budget demo pie chart.
	/// </summary>
	public class BudgetDoughnutChart : AbstractDemoChart
	{
	  /// <summary>
	  /// Returns the chart name.
	  /// </summary>
	  /// <returns> the chart name </returns>
	  public override string Name
	  {
		  get
		  {
			return "Budget chart for several years";
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
			return "The budget per project for several years (doughnut chart)";
		  }
	  }

	  /// <summary>
	  /// Executes the chart demo.
	  /// </summary>
	  /// <param name="context"> the context </param>
	  /// <returns> the built intent </returns>
	  public override Intent Execute(Context context)
	  {
		IList<double[]> values = new List<double[]>();
		values.Add(new double[] {12, 14, 11, 10, 19});
		values.Add(new double[] {10, 9, 14, 20, 11});
		IList<string[]> titles = new List<string[]>();
		titles.Add(new string[] {"P1", "P2", "P3", "P4", "P5"});
		titles.Add(new string[] {"Project1", "Project2", "Project3", "Project4", "Project5"});
		int[] colors = new int[] {Color.Blue, Color.Green, Color.Magenta,  Color.Yellow, Color.Cyan};

		DefaultRenderer renderer = BuildCategoryRenderer(colors);
		renderer.ApplyBackgroundColor = true;
		renderer.BackgroundColor = Color.Rgb(222, 222, 200);
		renderer.LabelsColor = Color.Gray;
		return ChartFactory.GetDoughnutChartIntent(context, BuildMultipleCategoryDataset("Project budget", titles, values), renderer, "Doughnut chart demo");
	  }

	}

}