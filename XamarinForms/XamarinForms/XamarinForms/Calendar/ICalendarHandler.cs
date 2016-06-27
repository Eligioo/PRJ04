using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Project4.Calendar
{
    public interface ICalendarHandler
    {
        void SaveAppointment(CalendarDetails calendar, DateTime dateTime, string title, string Description);
        IEnumerable<CalendarDetails> GetAllCalendars();
    }
}
