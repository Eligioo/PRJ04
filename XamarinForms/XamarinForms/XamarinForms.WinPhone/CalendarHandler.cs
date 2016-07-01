using Project4.Calendar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Appointments;
using Windows.Foundation;

[assembly: Xamarin.Forms.Dependency(typeof(XamarinForms.WinPhone.CalendarHandler))]
namespace XamarinForms.WinPhone
{
    public class CalendarHandler : ICalendarHandler
    {
        public CalendarHandler()
        {
            //
        }

        public IEnumerable<CalendarDetails> GetAllCalendars()
        {
            yield return new CalendarDetails
            {
                Id = 2,
                Name = "",
                AccountName = ""
            };
        }

        public async Task<bool> SaveAppointment(CalendarDetails calendar, DateTime dateTime, string title, string Description, string location = "")
        {
            var appointment = new Windows.ApplicationModel.Appointments.Appointment();
            
            appointment.StartTime = dateTime;
            appointment.Duration = TimeSpan.FromHours(1);
            appointment.Location = location;
            appointment.Subject = title;
            appointment.Details = Description;
            Rect rect = new Rect(new Point(10, 10), new Size(100, 200));
            try
            {
                String appointmentId =
                    await Windows.ApplicationModel.Appointments.AppointmentManager.ShowEditNewAppointmentAsync(appointment);

                return !string.IsNullOrEmpty(appointmentId);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}