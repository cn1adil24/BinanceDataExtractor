using System;

namespace DataManipulator
{
    class DateTimeManipulator : IPerformsDataManipulation
    {
        #region IPerformsDataManipulation Members

        public DelimitedHandler Handler { get; set; }

        public event EventHandler<string> SendFeedback;

        #endregion

        public DateTimeManipulator(DelimitedHandler handler)
        {
            Handler = handler;
        }

        public void Perform()
        {
            var dateConverter = new DatetimeConverter(Handler);

            ConvertGMTtoDesired(5, "Open time", "Open time");
            ConvertGMTtoDesired(5, "Close time", "Close time");
            AddWeekDays("Open time", "Open day");
            AddWeekDays("Close time", "Close day");
            AddTimeInFormat("MM/dd/yyyy HH:mm", "Open time", "Open time");
            AddTimeInFormat("MM/dd/yyyy HH:mm", "Close time", "Close time");

            RaiseSendFeedback("<Date> transformations completed successfully.");

            void AddWeekDays(string previousName, string newName)
            {
                RaiseSendFeedback($"Adding Week Day for column <{previousName}>");
                var daysList = dateConverter.EpochToWeekDays(previousName);
                Handler.AddRange(daysList, newName);
            }

            void AddTimeInFormat(string format, string previousName, string newName)
            {
                RaiseSendFeedback($"Adding Time in <{format}> format for column <{previousName}>");
                var timeList = dateConverter.EpochToTime(previousName, format);
                Handler.AddRange(timeList, newName);
            }

            void ConvertGMTtoDesired(int hours, string previousName, string newName)
            {
                RaiseSendFeedback($"Converting GMT+0 to <GMT+{hours}> for <{previousName}>");
                var timeList = dateConverter.EpochGMTtoDesiredTimezone(previousName, hours);
                Handler.AddRange(timeList, newName);
            }
        }

        private void RaiseSendFeedback(string message)
        {
            SendFeedback?.Invoke(this, message);
        }
    }
}
