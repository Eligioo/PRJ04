using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Locations;
using Android.Util;
using System.Collections.Generic;
using System.Linq;

namespace XamarinForms.Droid
{
    [Activity(Label = "Project4", Icon = "@drawable/hr_logo", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            OxyPlot.Xamarin.Forms.Platform.Android.PlotViewRenderer.Init();
            LoadApplication(new App());
        }
    }
}

