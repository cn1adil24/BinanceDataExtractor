using System;
using System.Collections.Generic;
using System.IO;

namespace DataExtractor
{
    public class DelimitedReader : IDisposable
    {
        private StreamReader _reader;
        private char _delimiter;
        private string[] _headers;
        private string _firstLine;

        private const string HeaderPlaceHolder = "Field_{0}";

        public DelimitedReader(string filePath, char delimiter = ',', bool containsHeaders = true, string[] providedHeaders = null)
        {
            _reader = new StreamReader(filePath);
            _delimiter = delimiter;

            if (containsHeaders)
                ExtractHeaders();
            else if (providedHeaders != null)
                UseProvidedHeaders();
            else
                AddHeaders();

            void ExtractHeaders()
            {
                string headerLine = _reader.ReadLine();
                if (string.IsNullOrWhiteSpace(headerLine) == false)
                {
                    _headers = headerLine.Split(delimiter);
                }
            }

            void UseProvidedHeaders()
            {
                _headers = new string[providedHeaders.Length];
                Array.Copy(providedHeaders, _headers, _headers.Length);
            }

            void AddHeaders()
            {
                _firstLine = _reader.ReadLine();
                if (string.IsNullOrWhiteSpace(_firstLine) == false)
                {
                    var n = _firstLine.Split(delimiter).Length;

                    _headers = new string[n];

                    for (int i = 0; i < n; i++)
                        _headers[i] = string.Format(HeaderPlaceHolder, i);
                }
            }
        }

        public IEnumerable<Dictionary<string, string>> ReadAll()
        {
            if (string.IsNullOrEmpty(_firstLine) == false)
            {
                var firstLine = _firstLine;
                _firstLine = null;
                yield return ProcessLine(firstLine);
            }

            while (!_reader.EndOfStream)
            {
                string line = _reader.ReadLine();
                yield return ProcessLine(line);
            }

            Dictionary<string, string> ProcessLine(string line)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    string[] fields = line.Split(_delimiter);
                    if (fields.Length != _headers.Length)
                    {
                        throw new InvalidOperationException("Number of fields does not match the number of headers.");
                    }

                    var record = new Dictionary<string, string>();
                    for (int i = 0; i < _headers.Length; i++)
                    {
                        record[_headers[i]] = fields[i];
                    }

                    return record;
                }
                return null;
            }
        }

        public void Dispose()
        {
            if (_reader != null)
            {
                _reader.Dispose();
            }
        }
    }
}
