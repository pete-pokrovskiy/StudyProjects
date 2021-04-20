using System;

namespace Study.Console
{
    public class DateTimeTests
    {

        public static void GoThroughDateTimeRange()
        {
            TimeSpan startTime = TimeSpan.Parse("11:00:00");
            TimeSpan endTime = TimeSpan.Parse("17:00:00");
            
            DateTime now = DateTime.UtcNow.Date;
            System.Console.WriteLine($"Now is: {now}");
            
            System.Console.WriteLine($"Now time of day is: {now.TimeOfDay}");
            
            //DateTime dateTo = new DateTime(2022, 12, 31, 17, 0, 0, DateTimeKind.Utc);
            DateTime dateTo = new DateTime(2020, 3, 9, 17, 0, 0, DateTimeKind.Utc);
            System.Console.WriteLine($"To is: {dateTo}");


            var dateToStartFrom = now.Add(startTime);

            while (dateToStartFrom.Date <= dateTo.Date)
            {
                dateToStartFrom = dateToStartFrom.Date.Add(startTime);
                while (dateToStartFrom < dateToStartFrom.Date.Add(endTime))
                {
                    System.Console.WriteLine(dateToStartFrom);
                    dateToStartFrom = dateToStartFrom.AddMinutes(30);
                }

                dateToStartFrom = GetNextWorkingDayDate(dateToStartFrom);
            }
            
        }

        private static DateTime GetNextWorkingDayDate(DateTime dt)
        {

            dt = dt.Date;

            while (true)
            {
                dt = dt.AddDays(1);
                if (dt.DayOfWeek != DayOfWeek.Saturday && dt.DayOfWeek != DayOfWeek.Sunday)
                {
                    break;
                }
            }

            return dt;
        }


        public static void TestDateTimeKind()
        {
            // Get the date and time for the current moment, adjusted 
// to the local time zone.

            DateTime saveNow = DateTime.Now;

// Get the date and time for the current moment expressed 
// as coordinated universal time (UTC).

            DateTime saveUtcNow = DateTime.UtcNow;
            DateTime myDt;

// Display the value and Kind property of the current moment 
// expressed as UTC and local time.

            DisplayNow("UtcNow: ..........", saveUtcNow);
            DisplayNow("Now: .............", saveNow);
            System.Console.WriteLine();

// Change the Kind property of the current moment to 
// DateTimeKind.Utc and display the result.

            myDt = DateTime.SpecifyKind(saveNow, DateTimeKind.Utc);
            Display("Utc: .............", myDt);

// Change the Kind property of the current moment to 
// DateTimeKind.Local and display the result.

            myDt = DateTime.SpecifyKind(saveNow, DateTimeKind.Local);
            Display("Local: ...........", myDt);

// Change the Kind property of the current moment to 
// DateTimeKind.Unspecified and display the result.

            myDt = DateTime.SpecifyKind(saveNow, DateTimeKind.Unspecified);
            Display("Unspecified: .....", myDt);
        }
        
        public static string datePatt = @"M/d/yyyy hh:mm:ss tt";
        public static void Display(string title, DateTime inputDt)
        {
            DateTime dispDt = inputDt;
            string dtString;

// Display the original DateTime.

            dtString = dispDt.ToString(datePatt);
            System.Console.WriteLine("{0} {1}, Kind = {2}", 
                title, dtString, dispDt.Kind);

// Convert inputDt to local time and display the result. 
// If inputDt.Kind is DateTimeKind.Utc, the conversion is performed.
// If inputDt.Kind is DateTimeKind.Local, the conversion is not performed.
// If inputDt.Kind is DateTimeKind.Unspecified, the conversion is 
// performed as if inputDt was universal time.

            dispDt = inputDt.ToLocalTime();
            dtString = dispDt.ToString(datePatt);
            System.Console.WriteLine("  ToLocalTime:     {0}, Kind = {1}", 
                dtString, dispDt.Kind);

// Convert inputDt to universal time and display the result. 
// If inputDt.Kind is DateTimeKind.Utc, the conversion is not performed.
// If inputDt.Kind is DateTimeKind.Local, the conversion is performed.
// If inputDt.Kind is DateTimeKind.Unspecified, the conversion is 
// performed as if inputDt was local time.

            dispDt = inputDt.ToUniversalTime();
            dtString = dispDt.ToString(datePatt);
            System.Console.WriteLine("  ToUniversalTime: {0}, Kind = {1}", 
                dtString, dispDt.Kind);
            System.Console.WriteLine();
        }

// Display the value and Kind property for DateTime.Now and DateTime.UtcNow.

        public static void DisplayNow(string title, DateTime inputDt)
        {
            string dtString = inputDt.ToString(datePatt);
            System.Console.WriteLine("{0} {1}, Kind = {2}", 
                title, dtString, inputDt.Kind);
        }
        
    }
}