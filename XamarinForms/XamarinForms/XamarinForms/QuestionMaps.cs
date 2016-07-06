using Android.OS;
using Android.Util;
using Newtonsoft.Json;
using Project4.GeoLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace XamarinForms
{
    public class QuestionMaps : ContentPage
    {
        Geo geo;
        Button button;
        public QuestionMaps()
        {
            geo = new Geo();
            Title = "Fiets trommel";
            Label label = new Label
            {
                Text = "Plan route naar de dichtst bijzijnde fietstrommel",
                TextColor = Device.OnPlatform<Color>(Color.Default, Color.White, Color.Default)
            };
            button = new Button
            {
                Text = "Plan route"
            };
            button.Clicked += ClosestContainersClicked;

            StackLayout stacklayout = new StackLayout
            {
                BackgroundColor = Device.OnPlatform<Color>(Color.Default, Color.Black, Color.Default),
                Padding = new Thickness(50, 50, 50, 50),
                Children =
                {
                    label,
                    button
                }
            };

            this.Content = stacklayout;
        }

        async void ClosestContainersClicked(object sender, EventArgs e)
        {
            var location = await geo.GetLocation();
            try
            {
                using (var client = new HttpClient())
                {
                    button.IsEnabled = false;
                    string download = await client.GetStringAsync($"http://145.24.222.220/v2/questions/NearestContainer?x=" + location.Item1 + "&y=" + location.Item2 + "");
                    var addressContainer = JsonConvert.DeserializeObject<IEnumerable<BikeDataModels.BikeContainer>>(download).Last();

                    var navloc1 = WebUtility.UrlEncode(await geo.GetAddress());
                    var navloc2 = WebUtility.UrlEncode(await geo.GetAddress(addressContainer.XLocation, addressContainer.YLocation));

                    switch (Device.OS)
                    {
                        case TargetPlatform.iOS:
                            Device.OpenUri(
                                new Uri(string.Format("http://maps.apple.com/?saddr={0}&daddr={1}", navloc1, navloc2)));
                            break;
                        case TargetPlatform.Android:
                            Device.OpenUri(
                                new Uri(string.Format("http://maps.google.com/maps?saddr={0}&daddr={1}", navloc1, navloc2)));
                            break;
                        case TargetPlatform.Windows:
                        case TargetPlatform.WinPhone:
                            Device.OpenUri(
                                new Uri(string.Format("http://maps.google.com/maps?saddr={0}&daddr={1}", navloc1, navloc2)));
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Debug("test", ex.ToString());
            }
            finally
            {
                button.IsEnabled = true;
            }
        }
    }
}
