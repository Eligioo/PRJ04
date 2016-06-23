# Details

## AChartEngine

AChartEngine is a charting library for Android applications. It currently supports the 
following chart types:

*	line chart
*	area chart
*	scatter chart
*	time chart
*	bar chart
*	pie chart
*	bubble chart
*	doughnut chart
*	range (high-low) bar chart
*	dial chart / gauge
*	combined (any combination of line, cubic line, scatter, bar, range bar, bubble) chart
*	cubic line chart

All the above supported chart types can contain multiple series, can be displayed with 
the X axis horizontally (default) or vertically and support many other custom features. 
The charts can be built as a view that can be added to a view group or as an intent, 
such as it can be used to start an activity.
 

### Sample 

Sample of average temperature for 4 Greek islands:


		string[] titles = new string[] {"Air temperature"};
		IList<double[]> x = new List<double[]>();
		for (int i = 0; i < titles.Length; i++)
		{
		  x.Add(new double[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12});
		}
		IList<double[]> values = new List<double[]>();
		values.Add(new double[] {12.3, 12.5, 13.8, 16.8, 20.4, 24.4, 26.4, 26.1, 23.6, 20.3, 17.2, 13.9});
		int[] colors = new int[] {Color.Blue,  Color.Yellow};
		PointStyle[] styles = new PointStyle[] {PointStyle.Point, PointStyle.Point};
		XYMultipleSeriesRenderer renderer = new XYMultipleSeriesRenderer(2);
		SetRenderer(renderer, colors, styles);
		int length = renderer.SeriesRendererCount;
		for (int i = 0; i < length; i++)
		{
		  XYSeriesRenderer r = (XYSeriesRenderer) renderer.GetSeriesRendererAt(i);
		  r.LineWidth = 3f;
		}
		SetChartSettings(renderer, "Average temperature", "Month", "Temperature", 0.5, 12.5, 0, 32, Color.LightGray, Color.LightGray);
		renderer.XLabels = 12;
		renderer.YLabels = 10;
		renderer.SetShowGrid(true);
		renderer.XLabelsAlign = Android.Graphics.Paint.Align.Right;
		renderer.SetYLabelsAlign(Android.Graphics.Paint.Align.Right);
		renderer.ZoomButtonsVisible = true;
		renderer.SetPanLimits(new double[] {-10, 20, -10, 40});
		renderer.SetZoomLimits(new double[] {-10, 20, -10, 40});
		renderer.ZoomRate = 1.05f;
		renderer.LabelsColor = Color.White;
		renderer.XLabelsColor = Color.Green;
		renderer.SetYLabelsColor(0, colors[0]);
		renderer.SetYLabelsColor(1, colors[1]);

		renderer.SetYTitle("Hours", 1);
		renderer.SetYAxisAlign(Android.Graphics.Paint.Align.Right, 1);
		renderer.SetYLabelsAlign(Android.Graphics.Paint.Align.Left, 1);

		XYMultipleSeriesDataset dataset = BuildDataset(titles, x, values);
		values.Clear();
		values.Add(new double[] {4.3, 4.9, 5.9, 8.8, 10.8, 11.9, 13.6, 12.8, 11.4, 9.5, 7.5, 5.5});
		AddXYSeries(dataset, new string[] {"Sunshine hours"}, x, values, 1);

		Intent intent = ChartFactory.GetCubicLineChartIntent(context, dataset, renderer, 0.3f, "Average temperature");

## Links/References

More about the library:

*	[http://www.achartengine.org/](http://www.achartengine.org/)
*	[https://code.google.com/p/achartengine/](https://code.google.com/p/achartengine/)
*	[https://www.facebook.com/achartengine](https://www.facebook.com/achartengine)
*	[http://www.achartengine.org/content/javadoc/index.html](http://www.achartengine.org/content/javadoc/index.html)
*	[https://www.facebook.com/achartengine](https://www.facebook.com/achartengine)
*	[http://achartengine.org/content/download.html](http://achartengine.org/content/download.html)



