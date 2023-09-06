using DataExtractor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;

namespace UnitTestProject
{
    [TestClass]
    public class DelimitedReaderTests
    {
        private const string TestFilePath = "test_data.csv";
        private const string TestFilePathWithoutHeaders = "test_data_without_headers.csv";
        private const char Delimiter = ',';

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            File.WriteAllText(TestFilePath, "Header1,Header2,Header3\nValue1,Value2,Value3\nValue4,Value5,Value6");
            File.WriteAllText(TestFilePathWithoutHeaders, "Value1,Value2,Value3\nValue4,Value5,Value6");
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            File.Delete(TestFilePath);
            File.Delete(TestFilePathWithoutHeaders);
        }

        [TestMethod]
        public void ReadAll_WithHeaders_CorrectRecords()
        {
            using (var reader = new DelimitedReader(TestFilePath, Delimiter, containsHeaders: true))
            {
                var records = reader.ReadAll().ToList();

                Assert.AreEqual(2, records.Count);

                var firstRecord = records[0];
                Assert.AreEqual("Value1", firstRecord["Header1"]);
                Assert.AreEqual("Value2", firstRecord["Header2"]);
                Assert.AreEqual("Value3", firstRecord["Header3"]);

                var secondRecord = records[1];
                Assert.AreEqual("Value4", secondRecord["Header1"]);
                Assert.AreEqual("Value5", secondRecord["Header2"]);
                Assert.AreEqual("Value6", secondRecord["Header3"]);
            }
        }

        [TestMethod]
        public void ReadAll_WithoutHeaders_CorrectRecords()
        {
            using (var reader = new DelimitedReader(TestFilePathWithoutHeaders, Delimiter, containsHeaders: false))
            {
                var records = reader.ReadAll().ToList();

                Assert.AreEqual(2, records.Count);

                var firstRecord = records[0];
                Assert.AreEqual("Value1", firstRecord["Field_0"]);
                Assert.AreEqual("Value2", firstRecord["Field_1"]);
                Assert.AreEqual("Value3", firstRecord["Field_2"]);

                var secondRecord = records[1];
                Assert.AreEqual("Value4", secondRecord["Field_0"]);
                Assert.AreEqual("Value5", secondRecord["Field_1"]);
                Assert.AreEqual("Value6", secondRecord["Field_2"]);
            }
        }
    }
}
