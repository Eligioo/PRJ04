using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Provider;
using Project4.Calendar;
using Java.Util;

using Project4.Calendar;
using Android.Database;

using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(XamarinForms.Droid.CalendarHandler))]
namespace XamarinForms.Droid
{
    public class CalendarHandler : ICalendarHandler
    {
        public CalendarHandler()
        {
            //
        }

        public IEnumerable<CalendarDetails> GetAllCalendars()
        {
            // List Calendars
            var calendarsUri = CalendarContract.Calendars.ContentUri;

            string[] calendarsProjection = {
               CalendarContract.Calendars.InterfaceConsts.Id,
               CalendarContract.Calendars.InterfaceConsts.CalendarDisplayName,
               CalendarContract.Calendars.InterfaceConsts.AccountName
            };
            ICursor cursor = null;

            cursor = Forms.Context.ContentResolver.Query(calendarsUri, calendarsProjection, null, null, null);



            while (cursor.MoveToNext())
            {
                yield return new CalendarDetails
                {
                    Id = cursor.GetInt(cursor.GetColumnIndex(calendarsProjection[0])),
                    Name = cursor.GetString(cursor.GetColumnIndex(calendarsProjection[1])),
                    AccountName = cursor.GetString(cursor.GetColumnIndex(calendarsProjection[2]))
                };
            }


        }
    

        public void SaveAppointment(CalendarDetails calendar, DateTime dateTime, string title, string Description)
        {
            
            ContentValues eventValues = new ContentValues();
            eventValues.Put(CalendarContract.Events.InterfaceConsts.CalendarId, calendar.Id);
            eventValues.Put(CalendarContract.Events.InterfaceConsts.Title, title);
            eventValues.Put(CalendarContract.Events.InterfaceConsts.Description, Description);
            eventValues.Put(CalendarContract.Events.InterfaceConsts.Dtstart, GetDateTimeMS(dateTime));
            eventValues.Put(CalendarContract.Events.InterfaceConsts.Dtend, GetDateTimeMS2(dateTime));

            // GitHub issue #9 : Event start and end times need timezone support.
            // https://github.com/xamarin/monodroid-samples/issues/9
            eventValues.Put(CalendarContract.Events.InterfaceConsts.EventTimezone, "UTC");
            eventValues.Put(CalendarContract.Events.InterfaceConsts.EventEndTimezone, "UTC");

            var uri = Forms.Context.ContentResolver.Insert(CalendarContract.Events.ContentUri, eventValues);
            Console.WriteLine("Uri for new event: {0}", uri);
        }

        private long GetDateTimeMS(DateTime dateTime)
        {
            Calendar c = Calendar.GetInstance(Java.Util.TimeZone.Default);

            c.Set(Calendar.DayOfMonth, dateTime.Day);
            c.Set(Calendar.HourOfDay, 11);
            c.Set(Calendar.Minute, 00);
            c.Set(Calendar.Month, dateTime.Month-1);// 0 based
            c.Set(Calendar.Year, dateTime.Year);

            return c.TimeInMillis;
        }

        private long GetDateTimeMS2(DateTime dateTime)
        {
            Calendar c = Calendar.GetInstance(Java.Util.TimeZone.Default);

            c.Set(Calendar.DayOfMonth, dateTime.Day);
            c.Set(Calendar.HourOfDay, 13);
            c.Set(Calendar.Minute, 00);
            c.Set(Calendar.Month, dateTime.Month-1);
            c.Set(Calendar.Year, dateTime.Year);

            return c.TimeInMillis;
        }

        long GetDateTimeMS(int yr, int month, int day, int hr, int min)
        {
            Calendar c = Calendar.GetInstance(Java.Util.TimeZone.Default);

            c.Set(Calendar.DayOfMonth, day);
            c.Set(Calendar.HourOfDay, hr);
            c.Set(Calendar.Minute, min);
            c.Set(Calendar.Month, month);
            c.Set(Calendar.Year, yr);

            return c.TimeInMillis;
        }
    }
}