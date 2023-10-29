using DataExtractor;
using DataExtractor.Utility;
using System;

namespace BinanceDataExtractor
{
    class ApiDataExtractor
    {
        private readonly string ExtractionDirectory;
        private readonly string Pair = "UNIUSDT";
        private readonly string TimeFrame = "5m";
        private readonly string[] Headers = {
            "OpenTime", "Open", "High", "Low", "Close", "Volume", "CloseTime",
            "QuoteVolume", "Count", "TakerBuyVolume", "TakerBuyQuoteVolume", "Ignore"
        };

        public ApiDataExtractor()
        {
            ExtractionDirectory = $"C:\\Binance\\Dump\\{Pair}\\{TimeFrame}";
        }

        public ApiDataExtractor(string pair, string timeFrame) : this()
        {
            Pair = pair;
            TimeFrame = timeFrame;
        }

        public void GetAllData() => GetData(2019, 2022, 1, 12);

        public void GetDataRange(ExtractionRangeInfo rangeInfo) => GetData(rangeInfo.StartingYear, rangeInfo.EndingYear, rangeInfo.StartingMonth, rangeInfo.EndingMonth);

        private void GetData(int startYear, int endYear, int startMonth, int endMonth)
        {
            for (int year = startYear; year <= endYear; year++)
            {
                for (int month = startMonth; month <= endMonth; month++)
                {
                    var requestInfo = new RequestInfo(
                        Pair,
                        TimeFrame,
                        year,
                        month);

                    try
                    {
                        WriteMessage("\n============================================================");
                        HandleRequest(requestInfo, out string csvFileDownloaded);
                        WriteToDB(csvFileDownloaded);
                        WriteMessage("\n============================================================");
                    }
                    catch (Exception ex)
                    {
                        WriteMessage(ex.Message);
                    }
                }
            }

        }

        private void HandleRequest(RequestInfo requestInfo, out string filePath)
        {
            DownloadZip(requestInfo, out string zipFilePath);
            ExtractCsv(zipFilePath, out filePath);
        }

        private void WriteToDB(string csvFilePath)
        {
            if (string.IsNullOrEmpty(csvFilePath))
                return;

            var writer = new CsvToDBWriter(csvFilePath, false, Headers);
            writer.ProgressEvent += ProgressEvent;
            writer.ReadAndWrite();
        }

        private void DownloadZip(RequestInfo requestInfo, out string zipFilePath)
        {
            var fileDownloader = new BinanceFileDownloader();
            fileDownloader.ProgressEvent += ProgressEvent;
            fileDownloader.DownloadFile(requestInfo, out zipFilePath);
        }

        private void ExtractCsv(string zipFilePath, out string filePath)
        {
            var extractor = new ZipExtractor(ExtractionDirectory);
            extractor.ProgressEvent += ProgressEvent; ;
            extractor.ExtractCsv(zipFilePath, out filePath);
        }

        private void ProgressEvent(object sender, string e)
        {
            WriteMessage(e);
        }

        private void WriteMessage(string message) => Console.WriteLine(message);
    }
}

