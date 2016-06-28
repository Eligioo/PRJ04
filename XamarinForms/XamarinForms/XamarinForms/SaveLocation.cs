using Xamarin.Forms;
using System;
using Plugin.Geolocator;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;
using System.Linq;

namespace XamarinForms
{
    public class SaveLocation : ContentPage
    {
        Label label;
        Button button;
        Geocoder geoCoder;
        public SaveLocation()
        {
            geoCoder = new Geocoder();
            Title = "   Sla locatie op";
            label = new Label
            {
                Text = "Sla je locatie op",
                TextColor = Color.Black
            };

            button = new Button
            {
                Text = "Locatie opslaan"
            };

            button.Clicked += SaveGpsClicked;

            this.Content = new StackLayout
            {
                BackgroundColor = Color.White,
                Padding = new Thickness(50, 50, 50, 50),
                Children = {
                    // new Image { Source = Device.OnPlatform<string>(string.Empty, "hr.png", "Assets/hr.png") }
                    label,
                    button
                }
            };
        }
        async void SaveGpsClicked(object sender, EventArgs e)
        {
            try
            {
                button.IsEnabled = false;
                label.Text = "Getting...";
                var test = await CrossGeolocator.Current.GetPositionAsync(10000);
                label.Text = "Lat: " + test.Latitude.ToString() + " Long: " + test.Longitude.ToString();
                var position = new Position(test.Latitude, test.Longitude);
                var possibleAddresses = await geoCoder.GetAddressesForPositionAsync(position);
                DisplayAlert("TEST", possibleAddresses.First().ToString(), "Cancel");
                foreach (var address in possibleAddresses.First())
                    label.Text += address + "\n";
            }
            catch (Exception ex)
            {
                label.Text = ex.Message;
            }
            finally
            {
                button.IsEnabled = true;
            };
        }
    }
}