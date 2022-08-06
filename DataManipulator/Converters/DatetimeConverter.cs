using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManipulator
{
    class DatetimeConverter
    {
        private DelimitedHandler Reader;
        private const int EpochPerHour = 3600;
        private const int Milliseconds = 1000;

        public DatetimeConverter(DelimitedHandler reader)
        {
            Reader = reader;
        }

        public DateTime?[] EpochToDatetime(string columnName)
        {
            var convertedDateList = new List<DateTime?>();
            foreach (var item in Reader.GetColumnRange(columnName))
            {
                try
                {
                    var dateTime = GetDateTimeFromEpochs(Convert.ToInt64(item));
                    convertedDateList.Add(dateTime);
                }
                catch
                {
                    convertedDateList.Add(null);

                }
            }
            return convertedDateList.ToArray();
        }


        public string[] EpochToWeekDays(string columnName)
        {
            var convertedDateList = new List<string>();
            foreach (var item in Reader.GetColumnRange(columnName))
            {
                try
                {
                    var dateTime = GetDateTimeFromEpochs(Convert.ToInt64(item));
                    convertedDateList.Add(GetDayOfTheWeek(dateTime));
                }
                catch
                {
                    convertedDateList.Add(string.Empty);
                }
            }
            return convertedDateList.ToArray();
        }

        public string[] EpochToTime(string columnName, string format)
        {
            var convertedDateList = new List<string>();
            foreach (var item in Reader.GetColumnRange(columnName))
            {
                try
                {
                    var dateTime = GetDateTimeFromEpochs(Convert.ToInt64(item));
                    convertedDateList.Add(dateTime.ToString(format));
                }
                catch
                {
                    convertedDateList.Add(string.Empty);

                }
            }
            return convertedDateList.ToArray();
        }

        public string[] EpochGMTtoDesiredTimezone(string columnName, int hours)
        {
            var epochsToAdd = hours * EpochPerHour * Milliseconds;
            var convertedDateList = new List<string>();
            foreach (var item in Reader.GetColumnRange(columnName))
            {
                try
                {
                    var newEpochs = Int64.Parse(item) + epochsToAdd;
                    convertedDateList.Add(newEpochs.ToString());
                }
                catch
                {
                    convertedDateList.Add(null);

                }
            }
            return convertedDateList.ToArray();
        }

        private DateTime GetDateTimeFromEpochs(long seconds) => DateTimeOffset.FromUnixTimeMilliseconds(seconds).DateTime;

        private string GetDayOfTheWeek(DateTime dateTime) => dateTime.DayOfWeek.ToString();
    }
}
