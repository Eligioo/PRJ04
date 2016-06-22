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
	/// Project status demo bubble chart.
	/// </summary>
	public class ProjectStatusBubbleChart : AbstractDemoChart
	{
	  /// <summary>
	  /// Returns the chart name.
	  /// </summary>
	  /// <returns> the chart name </returns>
	  public override string Name
	  {
		  get
		  {
			return "Project tickets status";
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
			return "The opened tickets and the fixed tickets (bubble chart)";
		  }
	  }

	  /// <summary>
	  /// Executes the chart demo.
	  /// </summary>
	  /// <param name="context"> the context </param>
	  /// <returns> the built intent </returns>
	  public override Intent Execute(Context context)
	  {
		XYMultipleSeriesDataset series = new XYMultipleSeriesDataset();
		XYValueSeries newTicketSeries = new XYValueSeries("New Tickets");
		newTicketSeries.Add(1f, 2, 14);
		newTicketSeries.Add(2f, 2, 12);
		newTicketSeries.Add(3f, 2, 18);
		newTicketSeries.Add(4f, 2, 5);
		newTicketSeries.Add(5f, 2, 1);
		series.AddSeries(newTicketSeries);
		XYValueSeries fixedTicketSeries = new XYValueSeries("Fixed Tickets");
		fixedTicketSeries.Add(1f, 1, 7);
		fixedTicketSeries.Add(2f, 1, 4);
		fixedTicketSeries.Add(3f, 1, 18);
		fixedTicketSeries.Add(4f, 1, 3);
		fixedTicketSeries.Add(5f, 1, 1);
		series.AddSeries(fixedTicketSeries);

		XYMultipleSeriesRenderer renderer = new XYMultipleSeriesRenderer();
		renderer.AxisTitleTextSize = 16;
		renderer.ChartTitleTextSize = 20;
		renderer.LabelsTextSize = 15;
		renderer.LegendTextSize = 15;
		renderer.SetMargins(new int[] {20, 30, 15, 0});
		XYSeriesRenderer newTicketRenderer = new XYSeriesRenderer();
		newTicketRenderer.Color = Color.Blue;
		renderer.AddSeriesRenderer(newTicketRenderer);
		XYSeriesRenderer fixedTicketRenderer = new XYSeriesRenderer();
		fixedTicketRenderer.Color = Color.Green;
		renderer.AddSeriesRenderer(fixedTicketRenderer);

		SetChartSettings(renderer, "Project work status", "Priority", "", 0.5, 5.5, 0, 5, Color.Gray, Color.LightGray);
		renderer.XLabels = 7;
		renderer.YLabels = 0;
		renderer.SetShowGrid(false);
		return ChartFactory.GetBubbleChartIntent(context, series, renderer, "Project tickets");
	  }

	}

}