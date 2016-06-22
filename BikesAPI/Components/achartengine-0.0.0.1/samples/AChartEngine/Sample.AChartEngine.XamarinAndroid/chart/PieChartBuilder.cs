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
using Android.Widget;
using Android.Graphics;

using AChartEngine;
using AChartEngine.Models;
using AChartEngine.Renderers;
using Android.OS;
using Android.Views;

namespace Sample.AChartEngine.Demo.Charts
{

	[Activity (Label="PieChartBuilder")] 
	public class PieChartBuilder : Activity
	{
	  /// <summary>
	  /// Colors to be used for the pie slices. </summary>
	  private static int[] COLORS = new int[] {Color.Green, Color.Blue, Color.Magenta, Color.Cyan};
	  /// <summary>
	  /// The main series that will include all the data. </summary>
	  private CategorySeries mSeries = new CategorySeries("");
	  /// <summary>
	  /// The main renderer for the main dataset. </summary>
	  private DefaultRenderer mRenderer = new DefaultRenderer();
	  /// <summary>
	  /// Button for adding entered data to the current series. </summary>
	  private Button mAdd;
	  /// <summary>
	  /// Edit text field for entering the slice value. </summary>
	  private EditText mValue;
	  /// <summary>
	  /// The chart view that displays the data. </summary>
	  private GraphicalView mChartView;

	  protected override void OnRestoreInstanceState(Bundle savedState)
	  {
		base.OnRestoreInstanceState(savedState);
		mSeries = (CategorySeries) savedState.GetSerializable("current_series");
		mRenderer = (DefaultRenderer) savedState.GetSerializable("current_renderer");
	  }

	  protected override void OnSaveInstanceState(Bundle outState)
	  {
		base.OnSaveInstanceState(outState);
		outState.PutSerializable("current_series", mSeries);
		outState.PutSerializable("current_renderer", mRenderer);
	  }

	  protected override void OnCreate(Bundle savedInstanceState)
	  {
		base.OnCreate(savedInstanceState);
		SetContentView(Resource.Layout.xy_chart);
		mValue = FindViewById<EditText>(Resource.Id.xValue);
		mRenderer.ZoomButtonsVisible = true;
		mRenderer.StartAngle = 180;
		mRenderer.DisplayValues = true;

			mAdd = FindViewById<Button>(Resource.Id.add);
		mAdd.Enabled = true;
		mValue.Enabled = true;

		mAdd.SetOnClickListener(new OnClickListenerAnonymousInnerClassHelper(this));
	  }

	  private class OnClickListenerAnonymousInnerClassHelper : Java.Lang.Object, View.IOnClickListener
	  {
		  private readonly PieChartBuilder outerInstance;

		  public OnClickListenerAnonymousInnerClassHelper(PieChartBuilder outerInstance)
		  {
			  this.outerInstance = outerInstance;
		  }

		  public virtual void OnClick(View v)
		  {
			double value = 0;
			try
			{
			  value = double.Parse(outerInstance.mValue.Text.ToString());
			}
			catch (System.FormatException)
			{
			  outerInstance.mValue.RequestFocus();
			  return;
			}
			outerInstance.mValue.Text = "";
			outerInstance.mValue.RequestFocus();
			outerInstance.mSeries.Add("Series " + (outerInstance.mSeries.ItemCount + 1), value);
			SimpleSeriesRenderer renderer = new SimpleSeriesRenderer();
			renderer.Color = COLORS[(outerInstance.mSeries.ItemCount - 1) % COLORS.Length];
			outerInstance.mRenderer.AddSeriesRenderer(renderer);
			outerInstance.mChartView.Repaint();
		  }
	  }

		protected override void OnResume()
		{
			base.OnResume();
			if (mChartView == null)
			{
				LinearLayout layout = FindViewById<LinearLayout>(Resource.Id.chart);
				mChartView = ChartFactory.GetPieChartView(this, mSeries, mRenderer);
				mRenderer.ClickEnabled = true;
				mChartView.SetOnClickListener(new OnClickListenerAnonymousInnerClassHelper2(this));
				layout.AddView
						(
						mChartView, 
						new Android.Widget.LinearLayout.LayoutParams
									(
									Android.Widget.LinearLayout.LayoutParams.FillParent, 
									Android.Widget.LinearLayout.LayoutParams.FillParent
									)
						);
			}
			else
			{
				mChartView.Repaint();
			}
		}

	  private class OnClickListenerAnonymousInnerClassHelper2 : Java.Lang.Object, View.IOnClickListener
	  {
		  private readonly PieChartBuilder outerInstance;

		  public OnClickListenerAnonymousInnerClassHelper2(PieChartBuilder outerInstance)
		  {
			  this.outerInstance = outerInstance;
		  }

		  public void OnClick(View v)
		  {
			SeriesSelection seriesSelection = outerInstance.mChartView.CurrentSeriesAndPoint;
			if (seriesSelection == null)
			{
			  Toast.MakeText(outerInstance, "No chart element selected", ToastLength.Short).Show();
			}
			else
			{
			  for (int i = 0; i < outerInstance.mSeries.ItemCount; i++)
			  {
				outerInstance.mRenderer.GetSeriesRendererAt(i).Highlighted = i == seriesSelection.PointIndex;
			  }
			  outerInstance.mChartView.Repaint();
			  //mc++ mc#
			  //Toast.MakeTextuniquetempvar.Show();
				Toast.MakeText(outerInstance, "mc++??" ,ToastLength.Long).Show();
			}
		  }
	  }
	}

}