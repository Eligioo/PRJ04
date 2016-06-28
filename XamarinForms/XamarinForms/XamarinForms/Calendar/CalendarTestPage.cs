using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Project4.Calendar
{
    public class CalendarTestPage : ContentPage
    {
        readonly Picker picker;
        readonly DatePicker datePicker;

        IEnumerable<CalendarDetails> calendars;

        public CalendarTestPage()
        {
            calendars = DependencyService.Get<ICalendarHandler>().GetAllCalendars();
            datePicker = new DatePicker();
            datePicker.Date = DateTime.Now;
            datePicker.MinimumDate = DateTime.Now;
            var saveButton = new Button { Text = "save" };
            saveButton.Clicked += SaveButton_Clicked;


            picker = new Picker
            {
                Title = "Agenda",
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            foreach (var c in calendars)
            {
                picker.Items.Add($"{c.Name} ({c.AccountName})");
            }

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                //BackgroundColor = Color.White,
                //Padding = new Thickness(50, 50, 50, 50),
                Children = { picker, datePicker, saveButton }
            };
        }

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            if (picker.SelectedIndex != -1)
            {
                var agenda = calendars.ElementAt(picker.SelectedIndex);

                DependencyService.Get<ICalendarHandler>().SaveAppointment(agenda, datePicker.Date, "bike", "get bike");
            }
        }
    }
}
