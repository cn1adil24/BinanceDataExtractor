using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalAnalysis
{
    public class RSICalculator : ITechnicalIndicator
    {
        private bool _isInitialized;
        private double _previousPoint;
        private List<double> _PreviousGains;
        private List<double> _PreviousLosses;

        #region ITechnicalIndicator Members

        public double Result => RSI;

        public string Name { get; set; }

        public TimeFrame TimeFrame => TimeFrame.Minute;

        #endregion

        public double Length { get; set; }
        public double RSI { get; private set; }
        public double Tolerance { get; private set; }

        public RSICalculator(int length, string name = "RSI")
        {
            Name = name;
            Length = length;
            _PreviousGains = new List<double>();
            _PreviousLosses = new List<double>();
            Tolerance = 10e-20;
        }

        public void AddDataPoint(double dataPoint)
        {
            double gain, loss, avgGain, avgLoss;

            if (_isInitialized == false)
            {
                RSI = 0;
                _previousPoint = dataPoint;
                _isInitialized = true;
                return;
            }

            var difference = dataPoint - _previousPoint;
            gain = difference > 0 ? difference : 0;
            loss = difference < 0 ? -difference : 0;

            if (_PreviousGains.Count < Length)
            {
                _PreviousGains.Add(gain);
                _PreviousLosses.Add(loss);

                RSI = 0;
                return;
            }
            else
            {
                avgGain = _PreviousGains.Average();
                avgLoss = _PreviousLosses.Average();

                UpdateList(_PreviousGains, gain);
                UpdateList(_PreviousLosses, loss);
            }

            if (avgGain == 0)
            {
                RSI = 0;
                return;
            }

            if (avgLoss == 0)
            {
                RSI = 100;
                return;
            }

            var relativeStrength = avgGain / avgLoss;

            RSI = 100.0 - (100.0 / (1 + relativeStrength));
            _previousPoint = dataPoint;
        }

        private void UpdateList(List<double> listToUpdate, double dataPoint)
        {
            listToUpdate.RemoveAt(0);
            listToUpdate.Add(dataPoint);
        }

        // TestFunction

        public double TestRSICalculator(IEnumerable<double> closePrices)
        {
            var prices = closePrices as double[] ?? closePrices.ToArray();

            double sumGain = 0;
            double sumLoss = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                var difference = prices[i] - prices[i - 1];
                if (difference >= 0)
                {
                    sumGain += difference;
                }
                else
                {
                    sumLoss -= difference;
                }
            }

            if (sumGain == 0) return 0;
            if (Math.Abs(sumLoss) < Tolerance) return 100;

            var relativeStrength = sumGain / sumLoss;

            return 100.0 - (100.0 / (1 + relativeStrength));
        }
    }
}
