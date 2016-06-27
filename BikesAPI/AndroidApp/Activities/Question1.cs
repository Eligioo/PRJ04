using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using BikeDataModels;

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
using Newtonsoft.Json;
using AndroidApp;

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
            view.Model = graphFactory.createGraph(GraphType.Line, new GraphEffect(), new GraphData<int>("Question1", "Xtitel", "Ytitel", new List<int>()));

            using (var client = new WebClient()) {
                string download = client.DownloadString("http://145.24.222.220/v2/questions/q1");
                List<MostBikeContainer> barldlist = JsonConvert.DeserializeObject<List<MostBikeContainer>>(download);
                Log.Debug("barld123", download);
            }
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