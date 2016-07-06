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
        /// <summary>
        /// stolenbikepage creates a contentpage with 3 buttons with their respective event handler
        /// </summary>
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
        /// <summary>
        /// this event handler handles the event of the online button being pressed and then redirects the user to the police website
        /// </summary>
        void onOnlineButton(object sender, EventArgs e)
        {
            string url = "https://www.politie.nl/aangifte-of-melding-doen/aangifte-doen/aangifte-van-diefstal-fiets.html";
            CrossShare.Current.OpenBrowser(url);
        }
        /// <summary>
        /// this event handler handles the event of the station button being pressed and then shows the nearest police station
        /// </summary>
        async void onStationButton(object sender, EventArgs e)
        {
            //hier moet de functie om het dichtstbijzijnde politiebureau te vinden
            var geo = new Geo();
            var location = await geo.GetLocationDouble();

            var policeStations = new PoliceStations();
            var station = policeStations.GetNearestStation(location.Item1, location.Item2);

            await Navigation.PushModalAsync(new NearestPoliceStation(station));
        }
        /// <summary>
        /// this event handler handles the event of the sharebutton being pressed and then shows the share dialog
        /// </summary>
        void onShareButton(object sender, EventArgs e)
        {
            //hier moet de functie om de diefstal te stelen
        }
    }
}
