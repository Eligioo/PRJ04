using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeDataModels;
using Xamarin.Forms;

namespace Project4
{
    public class NearestPoliceStation : ContentPage
    {
        private PoliceStation station;

        public NearestPoliceStation(PoliceStation station)
        {
            this.station = station;
            Content = new StackLayout
            {
                Children =
                {
                    new Label {Text = $"naam: {station.Titel}" },
                    new Label {Text = $"adres: {station.BezoekAdres}" },
                    new Label {Text = $"lat: {station.Latitude} long: {station.Longitude}" }
                }
            };
        }
    }
}
