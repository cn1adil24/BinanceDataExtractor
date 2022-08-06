using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManipulator
{
    class DataPreparator : IPerformsDataManipulation
    {
        private List<IPerformsDataManipulation> _Manipulators = new List<IPerformsDataManipulation>();

        string SourceFilePath { get; set; }

        string DestinationFilePath { get; set; }

        #region IPerformsDataManipulation Members

        public DelimitedHandler Handler { get; set; }

        public event EventHandler<string> SendFeedback;

        #endregion

        public DataPreparator(string sourceFilePath, string destinationFilePath)
        {
            SourceFilePath = sourceFilePath;
            DestinationFilePath = destinationFilePath;
            Handler = new DelimitedHandler(SourceFilePath) { FilePath = SourceFilePath };
            AddOperations();
            AddEventHandlers();

            void AddOperations()
            {
                _Manipulators.Add(new DateTimeManipulator(Handler));
                _Manipulators.Add(new ChartMetricsManipulator(Handler));
            }

            void AddEventHandlers()
            {
                _Manipulators.ForEach(m => m.SendFeedback += Manipulators_SendFeedback);
            }
        }

        public void Perform()
        {
            ReadFile();

            PerformManipulation();

            WriteToFile();

            void ReadFile()
            {
                RaiseSendFeedback($"Reading file: {SourceFilePath}");
                Handler.ReadFile();
            }

            void WriteToFile()
            {
                Handler.FilePath = DestinationFilePath;
                RaiseSendFeedback($"Writing to file: {Handler.FilePath}");
                Handler.WriteToFile();
            }

            void PerformManipulation() => _Manipulators.ForEach(op => op.Perform());
        }

        private void Manipulators_SendFeedback(object sender, string e)
        {
            RaiseSendFeedback(e);
        }

        private void RaiseSendFeedback(string message)
        {
            SendFeedback?.Invoke(this, message);
        }
    }
}
