using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.IO.Compression;

namespace BinanceDataExtractor
{
    class ApiDataExtractor
    {
        private readonly string BaseURL = "https://data.binance.vision/data/spot/monthly/klines/{0}/{1}/{2}"; // {pair}/{timeframe}/{filename}
        private readonly string FileToDownload = "{0}-{1}-{2}-{3}.zip";  // {pair}-{timeframe}-{year}-{month}

        private readonly string ExtractionDirectory;
        private readonly string Pair = "UNIUSDT";
        private readonly string TimeFrame = "5m";

        private const string ResultCsvPath = "C:\\Binance\\result.csv";
        private const string BackSlash = "\\";

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
                        var csvFileDownloaded = HandleRequest(requestInfo);
                        File.AppendAllText(ResultCsvPath, File.ReadAllText(csvFileDownloaded));
                        WriteMessage("\n============================================================");
                    }
                    catch (Exception ex)
                    {
                        WriteMessage(ex.Message);
                    }
                }
            }

        }

        private string HandleRequest(RequestInfo requestInfo)
        {
            DownloadZip(requestInfo, out string zipFilePath);
            ExtractCsv(zipFilePath, out string filePath);
            return filePath;
        }

        private void DownloadZip(RequestInfo requestInfo, out string zipFilePath)
        {
            var fileToDownload = GetDownloadFileName(requestInfo);
            var url = string.Format(BaseURL, requestInfo.Pair, requestInfo.TimeFrame, fileToDownload);

            WriteMessage($"Sending request to download {fileToDownload}");
            var request = WebRequest.Create(url);
            request.Method = "GET";
            
            var webResponse = request.GetResponse();

            if (webResponse.ContentType != "application/zip")
                throw new Exception($"Failed to download file: {fileToDownload}");

            var webStream = webResponse.GetResponseStream();
            zipFilePath = WriteToZipFile();

            CloseResources();

            string WriteToZipFile()
            {
                var tempZipFileName = fileToDownload.Split('.')[0];
                var zipFileToWrite = Path.GetTempPath() + $"{tempZipFileName}.zip";
                using (var fs = File.OpenWrite(zipFileToWrite))
                {
                    webStream.CopyTo(fs);
                }
                return zipFileToWrite;
            }

            void CloseResources()
            {
                webResponse.Close();
                webStream.Close();
            }
        }
        
        private void ExtractCsv(string zipFilePath, out string filePath)
        {
            WriteMessage($"Extracting ZIP file to: {ExtractionDirectory}");
            ExtractZipFile();
            DeleteZipFile();
            filePath = GetExtractedCsvPath();
            WriteMessage($"CSV file downloaded to location: {filePath}");

            void ExtractZipFile() => ZipFile.ExtractToDirectory(zipFilePath, ExtractionDirectory);

            void DeleteZipFile() => File.Delete(zipFilePath);

            string GetExtractedCsvPath()
            {
                var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(zipFilePath);
                return ExtractionDirectory + BackSlash + fileNameWithoutExtension + ".csv";
            }
        }

        private string GetDownloadFileName(RequestInfo requestInfo) => string.Format(FileToDownload, requestInfo.Pair, requestInfo.TimeFrame, requestInfo.Year, requestInfo.MonthFormatted);

        private void WriteMessage(string message) => Console.WriteLine(message);
    }
}

