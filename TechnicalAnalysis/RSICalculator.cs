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
        private double _previousAvgGain = -1;
        private double _previousAvgLoss = -1;
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
        public bool ApplySmoothing { get; private set; }

        public RSICalculator(int length, string name = "RSI", bool applySmoothing = false)
        {
            Name = name;
            Length = length;
            ApplySmoothing = applySmoothing;
            _PreviousGains = new List<double>();
            _PreviousLosses = new List<double>();
            Tolerance = 10e-20;
        }

        public void AddDataPoint(double dataPoint)
        {
            double gain, loss, avgGain, avgLoss, difference;

            if (_isInitialized == false)
            {
                RSI = 0;
                _previousPoint = dataPoint;
                _isInitialized = true;
                return;
            }

            CalculateGainLoss();
            AddPreviousGainLoss(gain, loss);

            if (_PreviousGains.Count < Length)
            {
                RSI = 0;
                return;
            }
            else
            {
                if (ApplySmoothing && _previousAvgGain >= 0)
                {
                    avgGain = (_previousAvgGain * (Length - 1) + gain) / Length;
                    avgLoss = (_previousAvgLoss * (Length - 1) + loss) / Length;
                }
                else
                {
                    avgGain = _PreviousGains.Average();
                    avgLoss = _PreviousLosses.Average();
                }

                _previousAvgGain = avgGain;
                _previousAvgLoss = avgLoss;
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

            void CalculateGainLoss()
            {
                difference = dataPoint - _previousPoint;
                gain = difference > 0 ? difference : 0;
                loss = difference < 0 ? -difference : 0;
                _previousPoint = dataPoint;
            }
        }

        private void AddPreviousGainLoss(double gain, double loss)
        {
            if (_PreviousGains.Count < Length && _PreviousLosses.Count < Length)
            {
                _PreviousGains.Add(gain);
                _PreviousLosses.Add(loss);
            }
        }

        private void UpdateList(List<double> listToUpdate, double dataPoint)
        {
            listToUpdate.RemoveAt(0);
            listToUpdate.Add(dataPoint);
        }
    }
}
