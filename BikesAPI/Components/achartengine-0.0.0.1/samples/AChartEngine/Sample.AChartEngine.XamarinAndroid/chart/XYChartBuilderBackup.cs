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
using Android.App;
using Android.OS;
using Android.Widget;

using AChartEngine;
using AChartEngine.Models;
using AChartEngine.Renderers;
using Android.Views;
using Android.Graphics;

namespace Sample.AChartEngine.Demo.Charts
{

	[Activity (Label="XYChartBuilderBackup")] 
	public class XYChartBuilderBackup : Activity
	{
	  /// <summary>
	  /// The main dataset that includes all the series that go into a chart. </summary>
	  private XYMultipleSeriesDataset mDataset = new XYMultipleSeriesDataset();
	  /// <summary>
	  /// The main renderer that includes all the renderers customizing a chart. </summary>
	  private XYMultipleSeriesRenderer mRenderer = new XYMultipleSeriesRenderer();
	  /// <summary>
	  /// The most recently added series. </summary>
	  private XYSeries mCurrentSeries;
	  /// <summary>
	  /// The most recently created renderer, customizing the current series. </summary>
	  private XYSeriesRenderer mCurrentRenderer;
	  /// <summary>
	  /// Button for creating a new series of data. </summary>
	  private Button mNewSeries;
	  /// <summary>
	  /// Button for adding entered data to the current series. </summary>
	  private Button mAdd;
	  /// <summary>
	  /// Edit text field for entering the X value of the data to be added. </summary>
	  private EditText mX;
	  /// <summary>
	  /// Edit text field for entering the Y value of the data to be added. </summary>
	  private EditText mY;
	  /// <summary>
	  /// The chart view that displays the data. </summary>
	  private GraphicalView mChartView;

	  // private int index = 0;

	  protected override void OnSaveInstanceState(Bundle outState)
	  {
		base.OnSaveInstanceState(outState);
		// save the current data, for instance when changing screen orientation
		outState.PutSerializable("dataset", mDataset);
		outState.PutSerializable("renderer", mRenderer);
		outState.PutSerializable("current_series", mCurrentSeries);
		outState.PutSerializable("current_renderer", mCurrentRenderer);
	  }

	  protected override void OnRestoreInstanceState(Bundle savedState)
	  {
		base.OnRestoreInstanceState(savedState);
		// restore the current data, for instance when changing the screen
		// orientation
		mDataset = (XYMultipleSeriesDataset) savedState.GetSerializable("dataset");
		mRenderer = (XYMultipleSeriesRenderer) savedState.GetSerializable("renderer");
		mCurrentSeries = (XYSeries) savedState.GetSerializable("current_series");
		mCurrentRenderer = (XYSeriesRenderer) savedState.GetSerializable("current_renderer");
	  }

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.xy_chart);

			// the top part of the UI components for adding new data points
			mX = FindViewById<EditText>(Resource.Id.xValue);
			mY = FindViewById<EditText>(Resource.Id.yValue);
			mAdd = FindViewById<Button>(Resource.Id.add);

			// set some properties on the main renderer
			mRenderer.ApplyBackgroundColor = true;
			mRenderer.BackgroundColor = Color.Argb(100, 50, 50, 50);
			mRenderer.AxisTitleTextSize = 16;
			mRenderer.ChartTitleTextSize = 20;
			mRenderer.LabelsTextSize = 15;
			mRenderer.LegendTextSize = 15;
			mRenderer.SetMargins(new int[] {20, 30, 15, 0});
			mRenderer.ZoomButtonsVisible = true;
			mRenderer.PointSize = 5;

			// the button that handles the new series of data creation
			mNewSeries = FindViewById<Button>(Resource.Id.new_series);
			mNewSeries.SetOnClickListener(new OnClickListenerAnonymousInnerClassHelper(this));

			mAdd.SetOnClickListener(new OnClickListenerAnonymousInnerClassHelper2(this));
		}

	  private class OnClickListenerAnonymousInnerClassHelper : Java.Lang.Object, View.IOnClickListener
	  {
		  private readonly XYChartBuilderBackup outerInstance;

		  public OnClickListenerAnonymousInnerClassHelper(XYChartBuilderBackup outerInstance)
		  {
			  this.outerInstance = outerInstance;
		  }

		  public virtual void OnClick(View v)
		  {
			string seriesTitle = "Series " + (outerInstance.mDataset.SeriesCount + 1);
			// create a new series of data
			XYSeries series = new XYSeries(seriesTitle);
			outerInstance.mDataset.AddSeries(series);
			outerInstance.mCurrentSeries = series;
			// create a new renderer for the new series
			XYSeriesRenderer renderer = new XYSeriesRenderer();
			outerInstance.mRenderer.AddSeriesRenderer(renderer);
			// set some renderer properties
			renderer.PointStyle = global::AChartEngine.Charts.PointStyle.Circle;
			renderer.FillPoints = true;
			renderer.DisplayChartValues = true;
			renderer.DisplayChartValuesDistance = 10;
			outerInstance.mCurrentRenderer = renderer;
			outerInstance.SeriesWidgetsEnabled = true;

			outerInstance.mCurrentSeries.Add(1, 2);
			outerInstance.mCurrentSeries.Add(2, 3);
			outerInstance.mCurrentSeries.Add(3, 0.5);
			outerInstance.mCurrentSeries.Add(4, -1);
			outerInstance.mCurrentSeries.Add(5, 2.5);
			outerInstance.mCurrentSeries.Add(6, 3.5);
			outerInstance.mCurrentSeries.Add(7, 2.85);
			outerInstance.mCurrentSeries.Add(8, 3.25);
			outerInstance.mCurrentSeries.Add(9, 4.25);
			outerInstance.mCurrentSeries.Add(10, 3.75);
			outerInstance.mRenderer.SetRange(new double[] {0.5, 10.5, -1.5, 4.75});
			outerInstance.mChartView.Repaint();
		  }
	  }

	  private class OnClickListenerAnonymousInnerClassHelper2 : Java.Lang.Object, View.IOnClickListener
	  {
		  private readonly XYChartBuilderBackup outerInstance;

		  public OnClickListenerAnonymousInnerClassHelper2(XYChartBuilderBackup outerInstance)
		  {
			  this.outerInstance = outerInstance;
		  }

		  public virtual void OnClick(View v)
		  {
			double x = 0;
			double y = 0;
			try
			{
			  x = double.Parse(outerInstance.mX.Text.ToString());
			}
			catch (System.FormatException)
			{
			  outerInstance.mX.RequestFocus();
			  return;
			}
			try
			{
			  y = double.Parse(outerInstance.mY.Text.ToString());
			}
			catch (System.FormatException)
			{
			  outerInstance.mY.RequestFocus();
			  return;
			}
			// add a new data point to the current series
			outerInstance.mCurrentSeries.Add(x, y);
			outerInstance.mX.Text = "";
			outerInstance.mY.Text = "";
			outerInstance.mX.RequestFocus();
			// repaint the chart such as the newly added point to be visible
			outerInstance.mChartView.Repaint();
			// Bitmap bitmap = mChartView.toBitmap();
			// try {
			// File file = new File(Environment.getExternalStorageDirectory(),
			// "test" + index++ + ".png");
			// FileOutputStream output = new FileOutputStream(file);
			// bitmap.compress(CompressFormat.PNG, 100, output);
			// } catch (Exception e) {
			// e.printStackTrace();
			// }
		  }
	  }

		protected override void OnResume()
		{
			base.OnResume();
			if (mChartView == null)
			{
				LinearLayout layout = FindViewById<LinearLayout>(Resource.Id.chart);
				// mChartView = ChartFactory.getLineChartView(this, mDataset, mRenderer);
			// mChartView = ChartFactory.getBarChartView(this, mDataset, mRenderer,
			// Type.DEFAULT);
				mChartView = ChartFactory.GetScatterChartView(this, mDataset, mRenderer);

				// enable the chart click events
				mRenderer.ClickEnabled = true;
				mRenderer.SelectableBuffer = 100;
				mChartView.SetOnClickListener(new OnClickListenerAnonymousInnerClassHelper3(this));
				// an example of handling the zoom events on the chart
				mChartView.AddZoomListener(new ZoomListenerAnonymousInnerClassHelper(this), true, true);
				// an example of handling the pan events on the chart
				//mChartView.AddPanListener(new PanListenerAnonymousInnerClassHelper(this));
				layout.AddView
							(
							mChartView, 
							new Android.Widget.LinearLayout.LayoutParams
												(
													Android.Widget.LinearLayout.LayoutParams.FillParent, 
													Android.Widget.LinearLayout.LayoutParams.FillParent
												)
							);
				bool enabled = mDataset.SeriesCount > 0;
				SeriesWidgetsEnabled = enabled;
			}
			else
			{
				mChartView.Repaint();
			}
		}

	  private class OnClickListenerAnonymousInnerClassHelper3 : Java.Lang.Object, View.IOnClickListener
	  {
		  private readonly XYChartBuilderBackup outerInstance;

		  public OnClickListenerAnonymousInnerClassHelper3(XYChartBuilderBackup outerInstance)
		  {
			  this.outerInstance = outerInstance;
		  }

		  public virtual void OnClick(View v)
		  {
			// handle the click event on the chart
			SeriesSelection seriesSelection = outerInstance.mChartView.CurrentSeriesAndPoint;
			if (seriesSelection == null)
			{
			  Toast.MakeText(outerInstance, "No chart element was clicked", ToastLength.Short).Show();
			}
			else
			{
			  // display information of the clicked point
			  double[] xy = outerInstance.mChartView.ToRealPoint(0);

			  // mc++ mc#
			  //Toast.MakeTextuniquetempvar.Show();
					Toast.MakeText(outerInstance, "mc++??", ToastLength.Short).Show();
			}
		  }
	  }

	  private class ZoomListenerAnonymousInnerClassHelper : Java.Lang.Object, global::AChartEngine.Tools.IZoomListener
	  {
		  private readonly XYChartBuilderBackup outerInstance;

		  public ZoomListenerAnonymousInnerClassHelper(XYChartBuilderBackup outerInstance)
		  {
			  this.outerInstance = outerInstance;
		  }

		  public virtual void ZoomApplied(global::AChartEngine.Tools.ZoomEvent e)
		  {
			string type = "out";
			if (e.IsZoomIn)
			{
			  type = "in";
			}
			Android.Util.Log.Info("Zoom", "Zoom " + type + " rate " + e.ZoomRate);
		  }

		  public virtual void ZoomReset()
		  {
			Android.Util.Log.Info("Zoom", "Reset");
		  }
	  }

	  /*
	  mc++ mc# TODO
	  private class PanListenerAnonymousInnerClassHelper : Java.Lang.Object, global::AChartEngine.Tools.IPannedListener
	  {
		  private readonly XYChartBuilderBackup outerInstance;

		  public PanListenerAnonymousInnerClassHelper(XYChartBuilderBackup outerInstance)
		  {
			  this.outerInstance = outerInstance;
		  }

		  public virtual void PanApplied()
		  {
			Android.Util.Log.Info("Pan", "New X range=[" + outerInstance.mRenderer.XAxisMin + ", " + outerInstance.mRenderer.XAxisMax + "], Y range=[" + outerInstance.mRenderer.YAxisMax + ", " + outerInstance.mRenderer.YAxisMax + "]");
		  }
	  }
	  */

	  /// <summary>
	  /// Enable or disable the add data to series widgets
	  /// </summary>
	  /// <param name="enabled"> the enabled state </param>
	  private bool SeriesWidgetsEnabled
	  {
		  set
		  {
			mX.Enabled = value;
			mY.Enabled = value;
			mAdd.Enabled = value;
		  }
	  }
	}

}