namespace BinanceDataExtractor
{
    class RequestInfo
    {
        private int Month;

        public RequestInfo(string pair, string timeFrame, int year, int month)
        {
            Pair = pair;
            TimeFrame = timeFrame;
            Year = year;
            Month = month;
        }

        public string Pair { get; set; }
        public string TimeFrame { get; set; }
        public int Year { get; set; }

        public string MonthFormatted
        {
            get
            {
                if (Month > 9)
                    return Month.ToString();

                return "0" + Month;
            }
        }
    }
}
