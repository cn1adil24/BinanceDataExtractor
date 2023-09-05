using System;

namespace DataManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataPreparator = new DataPreparator("C:\\Binance\\result.csv", "C:\\Binance\\result-transformed-gmt5.csv");
            dataPreparator.SendFeedback += DateManipulator_SendFeedback;

            try
            {
                dataPreparator.Perform();
                WriteMessage("Data Preparation Successfully done");
            }
            catch (Exception ex)
            {
                WriteMessage(ex.Message);
            }

            Console.Read();
        }

        private static void DateManipulator_SendFeedback(object sender, string e)
        {
            WriteMessage(e);
        }

        public static void WriteMessage(string message) => Console.WriteLine(message);
    }
}
