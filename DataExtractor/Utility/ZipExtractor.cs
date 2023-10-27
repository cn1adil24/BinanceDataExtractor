using System;
using System.IO.Compression;
using System.IO;

namespace DataExtractor
{
    internal class ZipExtractor
    {
        private readonly string ExtractionDirectory;
        private const string BackSlash = "\\";
        private const string Csv = ".csv";

        public ZipExtractor(string extractionDirectory)
        {
            ExtractionDirectory = extractionDirectory;
        }

        public event EventHandler<string> ProgressEvent;

        public void ExtractCsv(string zipFilePath, out string filePath)
        {
            ProgressEvent?.Invoke(this, $"Extracting ZIP file to: {ExtractionDirectory}");
            ExtractZipFile();
            DeleteZipFile();
            filePath = GetExtractedCsvPath();
            ProgressEvent?.Invoke(this, $"CSV file downloaded to location: {filePath}");

            void ExtractZipFile() => ZipFile.ExtractToDirectory(zipFilePath, ExtractionDirectory);

            void DeleteZipFile() => File.Delete(zipFilePath);

            string GetExtractedCsvPath()
            {
                var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(zipFilePath);
                return ExtractionDirectory + BackSlash + fileNameWithoutExtension + Csv;
            }
        }
    }
}
