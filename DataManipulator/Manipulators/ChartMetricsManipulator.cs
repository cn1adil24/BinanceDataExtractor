using System;
using System.Collections.Generic;
using System.Linq;
using TechnicalAnalysis;

namespace DataManipulator
{
    class ChartMetricsManipulator : IPerformsDataManipulation
    {
        #region IPerformsDataManipulation Members

        public DelimitedHandler Handler { get; set; }

        public event EventHandler<string> SendFeedback;

        #endregion

        public string Source { get; private set; }

        private List<ITechnicalIndicator> _Indicators = new List<ITechnicalIndicator>();

        public ChartMetricsManipulator(DelimitedHandler handler)
        {
            Handler = handler;
            Source = "Close";
            AddIndicators();

            void AddIndicators()
            {
                _Indicators.Add(new EMACalculator(12, "EMA12"));
                _Indicators.Add(new EMACalculator(26, "EMA26"));
                _Indicators.Add(new RSICalculator(14, "RSI", true));
            }
        }

        public void Perform()
        {
            _Indicators.ForEach(ind => Calculate(ind));
        }

        private void Calculate(ITechnicalIndicator indicator)
        {
            RaiseSendFeedback($"Calculating {indicator.Name} for column <{Source}>");
            var values = new List<string>();
            var enumerator = Handler.GetColumnRange(Source).ToList();
            int iterator, aggregateIterations;
            iterator = aggregateIterations = GetAggregateIterations();
            double last = 0;

            do
            {
                last = double.Parse(enumerator[iterator]);

                indicator.AddDataPoint(last);

                values.AddRange(GenerateResultantList());

                iterator += aggregateIterations;

            } while (iterator < enumerator.Count && enumerator[iterator] != null);

            Handler.AddRange(values, indicator.Name);
            RaiseSendFeedback($"Added {indicator.Name} for column <{Source}>");

            int GetAggregateIterations()
            {
                switch (indicator.TimeFrame)
                {
                    case TimeFrame.Hourly:
                        return 12;
                    case TimeFrame.Day:
                        return 12 * 24;
                    case TimeFrame.Minute:
                        return 1;
                    default:
                        return 0;
                }
            }

            List<string> GenerateResultantList()
            {
                var resultList = Enumerable.Repeat(string.Empty, aggregateIterations).ToList();
                resultList[0] = indicator.Result.ToString();
                return resultList;
            }
        }

        private void RaiseSendFeedback(string message)
        {
            SendFeedback?.Invoke(this, message);
        }
    }
}
