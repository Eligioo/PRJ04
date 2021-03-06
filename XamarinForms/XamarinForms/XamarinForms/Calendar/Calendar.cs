﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Project4.GeoLocation;
using Java.Util;

namespace Project4.Calendar
{
    public class Calendar : ContentPage
    {
        readonly Picker picker;
        readonly DatePicker datePicker;
        readonly TimePicker timePicker;

        IEnumerable<CalendarDetails> calendars;
        int PlanCounter = 0;

        /// <summary>
        /// Class constructor
        /// </summary>
        public Calendar()
        {
            calendars = DependencyService.Get<ICalendarHandler>().GetAllCalendars();

            Title = "Fiets ophalen";
            DateTime DateTimeNow = DateTime.Now;
            timePicker = new TimePicker
            {
                Time = new TimeSpan(DateTimeNow.Hour+1, DateTimeNow.Minute, 0),
                BackgroundColor = Device.OnPlatform<Color>(Color.Default, Color.Black, Color.Default)
            };

            datePicker = new DatePicker
            {
                Date = DateTimeNow,
                MinimumDate = DateTimeNow,
                BackgroundColor = Device.OnPlatform<Color>(Color.Default, Color.Black, Color.Default),
            };

            Button saveButton = new Button
            {
                Text = "Sla op"
            };
            saveButton.Clicked += SaveButtonClicked;

            picker = new Picker
            {
                Title = "Agenda",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                BackgroundColor = Device.OnPlatform<Color>(Color.Default, Color.Black, Color.Default),
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
                BackgroundColor = Device.OnPlatform<Color>(Color.Default, Color.Black, Color.Default),
                Padding = new Thickness(50, 50, 50, 50),
                Children = { picker, datePicker, timePicker, saveButton }
            };
        }

        /// <summary>
        /// Method that is triggerd when the SaveButton is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void SaveButtonClicked(object sender, EventArgs e)
        {
            if (picker.SelectedIndex != -1)
            {
                try
                {
                    var agenda = calendars.ElementAt(picker.SelectedIndex);
                    Geo geo = new Geo();
                    await geo.GetLocation();
                    string address = await geo.GetAddress();

                    string location = $"{geo.Location.Item1}, {geo.Location.Item2}";

                    if (await DependencyService.Get<ICalendarHandler>().SaveAppointment(agenda, datePicker.Date.Date + timePicker.Time, "Fiets ophalen", address, location))
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
                        SaveButtonClicked(sender, e);
                    }
                }
            }
        }
    }
}
