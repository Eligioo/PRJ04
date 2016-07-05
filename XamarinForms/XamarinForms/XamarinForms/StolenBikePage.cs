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

namespace XamarinForms
{
    public class StolenBikePage : ContentPage
    {
        public StolenBikePage()
        {
            Button onlineButton = new Button
            {
                VerticalOptions = LayoutOptions.StartAndExpand,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Text = "Doe aangifte online"
            };
            Button stationButton = new Button
            {
                VerticalOptions = LayoutOptions.EndAndExpand,
                HorizontalOptions = LayoutOptions.EndAndExpand,
                Text = "Zoek Dichtstbijzijnde politiebureau"
            };
            Button shareButton = new Button
            {
                VerticalOptions = LayoutOptions.EndAndExpand,
                HorizontalOptions = LayoutOptions.EndAndExpand,
                Text = "Deel dit op sociale media"
            };
            onlineButton.Clicked += onOnlineButton;
            stationButton.Clicked += onStationButton;
            shareButton.Clicked += onShareButton;
            var buttonList = new List<Button>();
            buttonList.Add(onlineButton);
            buttonList.Add(stationButton);
            buttonList.Add(shareButton);
            var buttonListView = new ListView
            {
                ItemsSource = buttonList,
                ItemTemplate = new DataTemplate(() =>
                {
                    var textCell = new TextCell();
                    textCell.SetBinding(TextCell.TextProperty, "Text");
                    return textCell;
                }),
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            StackLayout buttonPage = new StackLayout
            {
                Children = { buttonListView }
            };
            this.Content = buttonPage;
        }
        void onOnlineButton(object sender, EventArgs e)
        {
            //hier moet de functie om de online pagina te openen
            //inappbrowser
        }
        void onStationButton(object sender, EventArgs e)
        {
            //hier moet de functie om het dichtstbijzijnde politiebureau te vinden
        }
        void onShareButton(object sender, EventArgs e)
        {
            //hier moet de functie om de diefstal te stelen
        }
    }
}
