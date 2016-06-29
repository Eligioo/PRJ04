using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Project4.GeoLocation;

namespace Project4.Calendar
{
    public class CalendarTestPage : ContentPage
    {
        readonly Picker picker;
        readonly DatePicker datePicker;
        readonly TimePicker timePicker;

        IEnumerable<CalendarDetails> calendars;
        int PlanCounter = 0;

        public CalendarTestPage()
        {
            calendars = DependencyService.Get<ICalendarHandler>().GetAllCalendars();

            timePicker = new TimePicker();
            datePicker = new DatePicker();
            datePicker.Date = DateTime.Now;
            datePicker.MinimumDate = DateTime.Now;
            var saveButton = new Button { Text = "save" };
            saveButton.Clicked += SaveButton_Clicked;

            Title = "fiets ophalen";

            picker = new Picker
            {
                Title = "Agenda",
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            foreach (var c in calendars)
            {
                picker.Items.Add($"{c.Name} ({c.AccountName})");
            }

            if (calendars.Count() == 0)
                DisplayAlert("Info", "Er zijn geen Agenda's gevonden", "ok");
            else
                picker.SelectedIndex = 0;

            Content = new StackLayout
            {
                //VerticalOptions = LayoutOptions.FillAndExpand,
                //BackgroundColor = Color.White,
                Padding = new Thickness(50, 50, 50, 50),
                Children = { picker, datePicker, timePicker, saveButton }
            };
        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            if (picker.SelectedIndex != -1)
            {
                try
                {
                    var agenda = calendars.ElementAt(picker.SelectedIndex);
                    Geo geo = new Geo();
                    var position = await geo.GetLocation();
                    string address = await geo.GetAddress();

                    string location = $"{geo.Latitude}, {geo.Longitude}";

                    if (DependencyService.Get<ICalendarHandler>().SaveAppointment(agenda, datePicker.Date.Date + timePicker.Time, "bike", address, location))
                    {
                        await DisplayAlert("info", "de afspraak is succesvol ingeland", "ok");
                    }
                }
                catch
                {
                    if (PlanCounter >= 3)
                    {
                        await DisplayAlert("info", "er is een fout opgetreden, controleer uw internet verbinding.", "ok");
                    }
                    else
                    {
                        PlanCounter++;
                        SaveButton_Clicked(sender, e);
                    }
                }
            }
        }
    }
}
