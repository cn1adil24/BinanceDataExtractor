namespace TechnicalAnalysis
{
    public interface ITechnicalIndicator
    {
        double Result { get; }
        string Name { get; set; }
        void AddDataPoint(double dataPoint);
        TimeFrame TimeFrame { get; }
    }

    public enum TimeFrame
    {
        Second,
        Minute,
        Hourly,
        Day
    }
}
