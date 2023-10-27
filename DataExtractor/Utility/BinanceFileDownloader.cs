using BinanceDataExtractor;
using System;
using System.IO;
using System.Net;

namespace DataExtractor.Utility
{
    internal class BinanceFileDownloader
    {
        private readonly string BaseURL = "https://data.binance.vision/data/spot/monthly/klines/{0}/{1}/{2}"; // {pair}/{timeframe}/{filename}
        private readonly string FileToDownload = "{0}-{1}-{2}-{3}.zip";  // {pair}-{timeframe}-{year}-{month}

        public event EventHandler<string> ProgressEvent;

        public void DownloadFile(RequestInfo requestInfo, out string zipFilePath)
        {
            var fileToDownload = GetDownloadFileName();
            var url = string.Format(BaseURL, requestInfo.Pair, requestInfo.TimeFrame, fileToDownload);

            ProgressEvent?.Invoke(this, $"Sending request to download {fileToDownload}");
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

            string GetDownloadFileName() => string.Format(FileToDownload, requestInfo.Pair, requestInfo.TimeFrame, requestInfo.Year, requestInfo.MonthFormatted);
        }
    }
}
