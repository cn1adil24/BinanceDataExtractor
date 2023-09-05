namespace TechnicalAnalysis
{
    public class EMACalculator : ITechnicalIndicator
    {
        private bool _isInitialized;
        private readonly int _lookback;
        private readonly double _weightingMultiplier;
        private double _previousAverage;

        #region ITechnicalIndicator Members

        public double Result => Average;

        public string Name { get; set; }

        public TimeFrame TimeFrame => TimeFrame.Hourly;

        #endregion

        public double Average { get; private set; }
        public double Slope { get; private set; }

        public EMACalculator(int lookback, string name = "EMA")
        {
            _lookback = lookback;
            _weightingMultiplier = 2.0 / (lookback + 1);
            Name = name;
        }

        public void AddDataPoint(double dataPoint)
        {
            if (_isInitialized == false)
            {
                Average = dataPoint;
                Slope = 0;
                _previousAverage = Average;
                _isInitialized = true;
                return;
            }

            Average = ((dataPoint - _previousAverage) * _weightingMultiplier) + _previousAverage;
            Slope = Average - _previousAverage;

            _previousAverage = Average;
        }
    }
}
