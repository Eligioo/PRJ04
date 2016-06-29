using Xamarin.Forms;
using System;
using Plugin.Geolocator;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;
using System.Linq;
using Project4.GeoLocation;

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
                label.Text = "";
                Geo geo = new Geo();
                var position = await geo.GetLocation();
                var location = await geo.GetAddress();
                label.Text = location;

            }
            catch (Exception ex)
            {
                SaveGpsClicked(sender, e);
            }
            finally
            {
                button.IsEnabled = true;
            };
        }
    }
}