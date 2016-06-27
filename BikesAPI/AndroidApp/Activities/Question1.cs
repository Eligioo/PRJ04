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

            List<MostBikeContainer> mostTrommelList;

            using (var client = new WebClient())
            {
                string download = client.DownloadString("http://145.24.222.220/v2/questions/q1");
                mostTrommelList = JsonConvert.DeserializeObject<List<MostBikeContainer>>(download);
            }

            List<Tuple<string, float>> b = new List<Tuple<string, float>>();

            foreach (var item in mostTrommelList)
            {
                b.Add(new Tuple<string, float>(item.Neighborhoods, (float)item.Count));
            }

            GraphFactory graphFactory = new GraphFactory();
            view.Model = graphFactory.createGraph(GraphType.Bar, new GraphEffect(), new GraphData("Question1", "Neighbourhood", "Trommels", b));

            
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