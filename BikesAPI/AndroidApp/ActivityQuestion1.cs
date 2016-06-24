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

namespace AndroidApp
{
    //[Activity(Label = "Activity1", MainLauncher = false, Icon = "@drawable/icon")]
    public class Question1Fragment : Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var textToDisplay = new StringBuilder().Insert(0, "The quick brown fox jumps over the lazy dog. ", 450).ToString();
            var view = inflater.Inflate(Resource.Layout.Main, container, false);
            var textView = view.FindViewById<TextView>(Resource.Id.text_view);
            textView.Text = textToDisplay;
            return view;
            // Create your application here
        }
    }
}