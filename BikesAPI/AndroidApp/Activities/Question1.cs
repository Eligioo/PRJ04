using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using OxyPlot.Xamarin.Android;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using Android.Util;

namespace AndroidApp
{
    [Activity(Label = "Question1")]
    public class Question1 : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Question1);

            PlotView view = FindViewById<PlotView>(Resource.Id.plot_view);

            GraphFactory<int> graphFactory = new GraphFactory<int>();
            view.Model = graphFactory.createGraph(GraphType.Line, new GraphEffect(), new List<int>());
        }

        public override void OnBackPressed()
        {
            SlidingDrawer menuSlider = FindViewById<SlidingDrawer>(Resource.Id.menuSlider);
            if (menuSlider.IsOpened)
            {
                menuSlider.AnimateClose();
            }
            else {
                base.OnBackPressed();
            }
        }
    }
}