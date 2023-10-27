using DatabaseManager;
using DatabaseManager.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExtractor.Utility
{
    internal class CsvToDBWriter
    {
        private readonly DelimitedReader _reader;
        private readonly DatabaseWriter _writer;

        public CsvToDBWriter(string csvFilePath, bool containsHeaders = false)
        {
            _reader = new DelimitedReader(csvFilePath, containsHeaders: containsHeaders);
            _writer = new DatabaseWriter(new CandleStickDbContext());
        }

        public void ReadAndWrite()
        {
            foreach (var record in _reader.ReadAll())
                _writer.WriteRecord(record);

            _reader.Dispose();
        }
    }
}
