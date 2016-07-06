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
    /// <summary>
    /// Question of getting the closest bike container and navigate to it.
    /// </summary>
    public class QuestionMaps : ContentPage
    {
        Geo geo;
        Button button;
        /// <summary>
        /// Constructor to show the default buttons and labels.
        /// </summary>
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
        /// <summary>
        /// Click event that gets the closest bike container and opens the maps api in order to navigate.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

                    Device.OpenUri(
                        new Uri(geo.generateNavigation(navloc1, navloc2)));
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
