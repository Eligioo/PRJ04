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
using Project4;
using Project4.GeoLocation;
using Plugin.Share;

namespace XamarinForms
{
    public class StolenBikePage : ContentPage
    {
        public StolenBikePage()
        {
            Button onlineButton = new Button
            {
                Text = "Doe aangifte online"
            };
            Button stationButton = new Button
            {
                Text = "Zoek Dichtstbijzijnde politiebureau"
            };
            Button shareButton = new Button
            {
                Text = "Deel dit op sociale media"
            };
            onlineButton.Clicked += onOnlineButton;
            stationButton.Clicked += onStationButton;
            shareButton.Clicked += onShareButton;
            StackLayout buttonPage = new StackLayout
            {
                Children =
                {
                    onlineButton,
                    stationButton,
                    shareButton
                }
            };
            this.Content = buttonPage;
        }
        void onOnlineButton(object sender, EventArgs e)
        {
            string url = "https://www.politie.nl/aangifte-of-melding-doen/aangifte-doen/aangifte-van-diefstal-fiets.html";
            CrossShare.Current.OpenBrowser(url);
        }

        /// <summary>
        /// Method is triggerd when the user clicks on the stationButton for finding the nearest police station.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void onStationButton(object sender, EventArgs e)
        {
            //hier moet de functie om het dichtstbijzijnde politiebureau te vinden
            var geo = new Geo();
            var location = await geo.GetLocationDouble();

            var policeStations = new PoliceStations();
            var station = policeStations.GetNearestStation(location.Item1, location.Item2);

            Navigation.PushModalAsync(new NearestPoliceStation(station));
        }
        async void onShareButton(object sender, EventArgs e)
        {
            var geo = new Geo();
            try {
                var location = await geo.GetLocation();
                var address = await geo.GetAddress();
                try {
                    await CrossShare.Current.Share("Help mijn fiets terug te vinden, voor het laatst gezien bij " + address + ".", "Help: mijn fiets is gestolen.");
                }
                catch { }
            }
            catch { }            
        }
    }
}
