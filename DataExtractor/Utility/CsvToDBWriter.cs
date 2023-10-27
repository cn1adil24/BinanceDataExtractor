using DatabaseManager;
using DatabaseManager.Data;

namespace DataExtractor.Utility
{
    internal class CsvToDBWriter
    {
        private readonly DelimitedReader _reader;
        private DatabaseWriter _writer;

        public CsvToDBWriter(string csvFilePath, bool containsHeaders = false, string[] providedHeaders = null)
        {
            _reader = new DelimitedReader(csvFilePath, containsHeaders: containsHeaders, providedHeaders: providedHeaders);
        }

        public void ReadAndWrite()
        {
            using (var dbContext = new CandleStickDbContext())
            {
                _writer = new DatabaseWriter(dbContext);
                _writer.WriteAll(_reader.ReadAll());
                _reader.Dispose();
            }
        }
    }
}
