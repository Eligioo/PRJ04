using Android.App;
using Android.OS;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using OxyPlot.Xamarin.Android;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System.Collections.Generic;

namespace AndroidApp
{
    [Activity(Label = "Project4 Groep1", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            /*PlotView view = FindViewById<PlotView>(Resource.Id.plot_view);

            GraphFactory<int> graphFactory = new GraphFactory<int>();
            view.Model = graphFactory.createGraph(GraphType.Line, new GraphEffect(), new List<int>());*/
            SlidingDrawer menuSlider = FindViewById<SlidingDrawer>(Resource.Id.menuSlider);
            
            Button MenuButton1 = FindViewById<Button>(Resource.Id.MenuButton1);
            MenuButton1.Click += delegate {
                StartActivity(typeof(Question1));
                menuSlider.Close();
            };
        }
        public override void OnBackPressed()
        {
            SlidingDrawer menuSlider = FindViewById<SlidingDrawer>(Resource.Id.menuSlider);
            if (menuSlider.IsOpened)
            {
                menuSlider.AnimateClose();
            }
            else
            {
                base.OnBackPressed();
            }
        }
    }
}