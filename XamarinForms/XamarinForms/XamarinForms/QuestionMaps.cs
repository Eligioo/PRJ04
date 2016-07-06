using Android.OS;
using Android.Util;
using Newtonsoft.Json;
using Project4.GeoLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace XamarinForms
{
    public class QuestionMaps : ContentPage
    {
        Map map;
        Geo geo;
        public QuestionMaps()
        {
            map = new Map
            {
                IsShowingUser = true,
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand,
                MapType = MapType.Street
            };
            geo = new Geo();
            int zoomLevel = 11;
            double latlongdegrees = 360 / (Math.Pow(2, zoomLevel));
            map.MoveToRegion(new MapSpan(new Position(51.9173770, 4.4839200), latlongdegrees, latlongdegrees));

            var button = new Button { Text = "Dichtst bijzijnde fietstrommel" };
            button.Clicked += ClosestContainersClicked;
            var segments = new StackLayout
            {
                Spacing = 30,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Orientation = StackOrientation.Horizontal,
                Children = { button }
            };

            var stack = new StackLayout { Spacing = 0 };
            stack.Children.Add(segments);
            stack.Children.Add(map);
            Content = stack;
        }

        async void ClosestContainersClicked(object sender, EventArgs e)
        {
            var b = sender as Button;
            var location = await geo.GetLocation();

            try
            {
                using (var client = new HttpClient())
                {
                    string download = await client.GetStringAsync($"http://145.24.222.220/v2/questions/NearestContainer?x="+location.Item2 + "&y="+location.Item1+"");
                    var cache = JsonConvert.DeserializeObject<IEnumerable<BikeDataModels.BikeContainer>>(download).Last();
                    Pin pin = new Pin
                    {
                        Position = new Position(cache.XLocation, cache.YLocation),
                        Label = cache.Street + " " + cache.StreetNumber
                    };
                    map.Pins.Add(pin);
                    Log.Debug("test", cache.XLocation.ToString());
                }
            }
            catch (Exception ex)
            {
                Log.Debug("test", $"http://145.24.222.220/v2/questions/NearestContainer?x=" + location.Item2 + "&y=" + location.Item1 + "");
                Log.Debug("test", ex.ToString());
            }
        }
    }
}
