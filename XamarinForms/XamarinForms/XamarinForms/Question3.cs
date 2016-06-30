using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.Xamarin.Forms;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using XamarinForms.Graphs;
using Newtonsoft.Json;
using BikeDataModels;
using System.Net.Http;
using Android.Util;

namespace Project4
{
    public class Question3 : ContentPage
    {
        private static bool loaded = false;
        private static List<CombinationofTheftTrommelAreaMonth> combinationList;
        public Question3()
        {
            if (!loaded)
            {
                loaded = true;
                Title = "         Vraag 3";
                using (var client = new HttpClient())
                {
                    string download = client.GetStringAsync("http://145.24.222.220/v2/questions/q1").Result;
                    combinationList = JsonConvert.DeserializeObject<List<CombinationofTheftTrommelAreaMonth>>(download);
                }
            }
            var 
        }
    }
}
