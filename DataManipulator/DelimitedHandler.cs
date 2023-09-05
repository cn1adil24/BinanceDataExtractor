using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DataManipulator
{
    public class DelimitedHandler
    {
        private const char Delimiter = ',';
        private Dictionary<string, List<string>> Values = new Dictionary<string, List<string>>();
        private List<string> Headers = new List<string>();

        public DelimitedHandler(string filePath)
        {
            FilePath = filePath;
            LoadHeaders();
        }

        public string FilePath { get; set; }

        public int Count { get; private set; }

        private void LoadHeaders()
        {
            try
            {
                using (StreamReader sr = new StreamReader(FilePath))
                {
                    string currentLine = sr.ReadLine();
                    var columnValues = currentLine.Split(Delimiter);
                    Array.ForEach(columnValues, AddHeader);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AddHeader(string name)
        {
            Headers.Add(name);
            AddEntryInDictionary(name);
        }

        private void AddEntryInDictionary(string key)
        {
            if (Values.ContainsKey(key) == false)
                Values.Add(key, new List<string>());
        }

        public void ReadFile()
        {
            try
            {
                using (StreamReader sr = new StreamReader(FilePath))
                {
                    // Skip the header
                    sr.ReadLine();

                    string currentLine;
                    while ((currentLine = sr.ReadLine()) != null)
                    {
                        if (string.IsNullOrWhiteSpace(currentLine))
                            continue;

                        var columnValues = currentLine.Split(Delimiter);
                        for (int i = 0; i < columnValues.Length; i++)
                        {
                            var value = columnValues[i];
                            var key = Headers[i];
                            Values[key].Add(value);
                        }
                        Count++;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void WriteToFile()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(FilePath))
                {
                    var headerLine = string.Join(",", Values.Keys);
                    sw.WriteLine(headerLine);

                    int i = 0;
                    string recordLine;
                    while ((recordLine = CreateRecord(i)) != null)
                    {
                        sw.WriteLine(recordLine);
                        i++;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            string CreateRecord(int row)
            {
                try
                {
                    string recordLine = "";
                    foreach (var key in Values.Keys)
                    {
                        recordLine += Values[key][row] + ",";
                    }
                    return recordLine.TrimEnd(',');
                }
                catch
                {
                    return null;
                }
            }
        }

        public System.Data.DataSet GetDataSet()
        {
            try
            {
                return ExtensionMethods.ConvertCSVtoDataSet(FilePath);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public IEnumerable<string> GetColumnRange(string columnName)
        {
            if (Values.ContainsKey(columnName))
            {
                foreach (var value in Values[columnName])
                    yield return value;
            }
            yield return null;
        }

        public IEnumerable<string> GetHeaders()
        {
            foreach (var key in Headers)
                yield return key;
        }

        public void AddRange(string[] values, string columnName)
        {
            AddRange(values.ToList(), columnName);
        }

        public void AddRange(List<string> values, string columnName)
        {
            if (Values.ContainsKey(columnName) == false)
                Values.Add(columnName, null);

            Values[columnName] = values;
        }

        public void DropRange(string columnName)
        {
            if (Values.ContainsKey(columnName))
            {
                Values[columnName].Clear();
                Values.Remove(columnName);
            }
        }
    }
}
