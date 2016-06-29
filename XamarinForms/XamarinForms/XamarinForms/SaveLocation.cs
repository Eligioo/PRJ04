using Xamarin.Forms;
using System;
using Plugin.Geolocator;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;
using System.Linq;
using Project4.GeoLocation;
using Android.Util;
using System.Collections;
using System.Collections.Generic;

namespace XamarinForms
{
    public interface ISaveOrLoadPosition
    {
        void SaveText(string filename, string Position);
        string LoadText(string filename);
    }
    public class SaveLocation : ContentPage
    {
        protected Label label;
        protected Button buttonSave, buttonLoad;
        protected Geo geo;
        protected string position;

        public SaveLocation()
        {
            this.geo = new Geo();
            Title = "   Sla locatie op";
            label = new Label
            {
                Text = "Sla je locatie op",
                TextColor = Color.Black
            };

            buttonSave = new Button
            {
                Text = "FietsLocatie opslaan"
            };

            buttonLoad = new Button
            {
                Text = "Fietslocatie ophalen"
            };

            buttonSave.Clicked += SaveGpsClicked;

            IList<View> Views = new List<View>();
            
            var stacklayout = new StackLayout
            {
                BackgroundColor = Color.White,
                Padding = new Thickness(50, 50, 50, 50),
                Children = { label, buttonSave }
            };
            if (CheckFileExists())
            {
                buttonLoad.Clicked += LoadGpsClicked;
                stacklayout.Children.Add(buttonLoad);
            }
            
            this.Content = stacklayout;

        }
        async void SaveGpsClicked(object sender, EventArgs e)
        {
            try
            {
                buttonSave.IsEnabled = false;
                label.Text = "Aan het ophalen...";
                await geo.GetLocation();
                var Address = await geo.GetAddress();
                DependencyService.Get<ISaveOrLoadPosition>().SaveText("temp.txt", Address);
                label.Text = "Fietslocatie: " + Address + " is successvol opgeslagen!";
            }
            catch (Exception ex)
            {
                label.Text = ex.ToString();
                //SaveGpsClicked(sender, e);
            }
            finally
            {
                buttonSave.IsEnabled = true;
            };
        }
        async void LoadGpsClicked(object sender, EventArgs e)
        {
            try
            {
                // var Location = await geo.GetLocation();
                label.Text = "Fietslocatie: " + DependencyService.Get<ISaveOrLoadPosition>().LoadText("temp.txt") + " is successvol opgehaald!";
            }
            catch (Exception ex)
            {
                if (ex.GetType() == (typeof(System.IO.FileNotFoundException)))
                {
                    Log.Error("Error location", "geen locatie opgeslagen!");
                    return;
                }
                Log.Error("Error location", ex.ToString());
            }
        }
        private bool CheckFileExists()
        {
            try
            {
                DependencyService.Get<ISaveOrLoadPosition>().LoadText("temp.txt");
                return true;
            }
            catch (Exception ex)
            {
                if (ex.GetType() == (typeof(System.IO.FileNotFoundException)))
                {
                    Log.Error("Error location", "geen locatie opgeslagen!");
                }
                Log.Error("Error location", ex.ToString());
            }
            return false;
        }
    }
}