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
using PCLStorage;

namespace XamarinForms
{
    public class SaveLocation : ContentPage
    {
        protected Label label;
        protected Button buttonSave, buttonLoad, buttonDelete;
        protected Geo geo;
        protected string position;
        readonly IFolder rootFolder;
        readonly string fileName;

        public SaveLocation()
        {
            this.geo   = new Geo();
            rootFolder = FileSystem.Current.LocalStorage;
            fileName   = "temp.txt";
            Title      = "Sla locatie op";
            label      = new Label
            {
                Text = "Sla je locatie op",
                TextColor = Device.OnPlatform<Color>(Color.Default, Color.White, Color.Default)
            };

            buttonSave = new Button
            {
                Text = "FietsLocatie opslaan",
            };
            buttonSave.Clicked += SaveGpsClicked;

            buttonLoad = new Button
            {
                Text = "Fietslocatie ophalen",
                IsVisible = false
            };
            buttonLoad.Clicked += LoadGpsClicked;

            buttonDelete = new Button
            {
                Text = "Fietslocatie verwijderen",
                IsVisible = false
            };
            buttonDelete.Clicked += DeleteGpsClecked;

            StackLayout stacklayout = new StackLayout
            {
                BackgroundColor = Device.OnPlatform<Color>(Color.Default, Color.Black,Color.Default),
                Padding         = new Thickness(50, 50, 50, 50),
                Children        =
                {
                    label,
                    buttonSave,
                    buttonLoad,
                    buttonDelete
                }
            };
            CheckFileExists();

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
                IFile file = await rootFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
                await file.WriteAllTextAsync(Address);
                label.Text = "Fietslocatie: " + Address + " is successvol opgeslagen!";
                ChangeButtonsVisibility(true);
            }
            catch (Exception ex)
            {
                label.Text = ex.ToString();
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
                buttonLoad.IsEnabled = false;
                IFile file = await rootFolder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists);
                string Address = await file.ReadAllTextAsync();
                label.Text = "Fietslocatie: " + Address + " is successvol opgehaald!";
            }
            catch (Exception ex)
            {
                label.Text = ex.ToString();
            }
            finally
            {
                buttonLoad.IsEnabled = true;
            };
        }
        async void DeleteGpsClecked(object sender, EventArgs e)
        {
            try
            {
                buttonDelete.IsEnabled = false;
                IFile file = await rootFolder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists);
                await file.DeleteAsync();
                label.Text = "Fietslocatie is successvol verwijdert!";
                ChangeButtonsVisibility(false);
            }
            catch (Exception ex)
            {
                label.Text = ex.ToString();
            }
            finally
            {
                buttonDelete.IsEnabled = true;
            };
        }
        private bool CheckFileExists()
        {
            try
            {
                IFile file = rootFolder.GetFileAsync(fileName).Result;
                ChangeButtonsVisibility(true);
                return true;
            }
            catch (Exception ex)
            {
                
            }
            return false;
        }
        private void ChangeButtonsVisibility(bool Visibility)
        {
            if (buttonLoad.IsVisible != Visibility && buttonDelete.IsVisible != Visibility)
            {
                buttonLoad.IsVisible = Visibility;
                buttonDelete.IsVisible = Visibility;
            }
            return;
        }
    }
}