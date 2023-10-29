using DatabaseManager;
using DatabaseManager.Data;
using System;

namespace DataExtractor.Utility
{
    internal class CsvToDBWriter
    {
        private readonly DelimitedReader _reader;
        private DbManager _writer;

        public CsvToDBWriter(string csvFilePath, bool containsHeaders = false, string[] providedHeaders = null)
        {
            _reader = new DelimitedReader(csvFilePath, containsHeaders: containsHeaders, providedHeaders: providedHeaders);
        }

        public event EventHandler<string> ProgressEvent;

        public void ReadAndWrite()
        {
            ProgressEvent?.Invoke(this, $"Writing records to database.");
            using (var dbContext = new CandleStickDbContext())
            {
                _writer = new DbManager(dbContext);
                _writer.WriteAll(_reader.ReadAll());
                _reader.Dispose();
            }
            ProgressEvent?.Invoke(this, $"Records successfully written to database.");
        }
    }
}
