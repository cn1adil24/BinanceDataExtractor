using AutoMapper;
using DatabaseManager;
using DatabaseManager.Data;
using DatabaseManager.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace UnitTestProject
{
    [TestClass]
    public class DatabaseWriterTests
    {
        [TestMethod]
        public void WriteRecord_SavesRecordToDatabase()
        {
            var dbContextMock = new Mock<ICandleStickDbContext>();
            var dbSetMock = new Mock<DbSet<Candlestick>>();
            dbContextMock.Setup(x => x.CandleStickData).Returns(dbSetMock.Object);

            var candleStickDataWriter = new DbManager(dbContextMock.Object);

            var record = new Dictionary<string, string>
            {
                { "OpenTime", "1672531200000" },
                { "Open", "5.16700000" },
                { "High", "5.17100000" },
                { "Low", "5.16300000" },
                { "Close", "5.16500000" },
                { "Volume", "1146.43000000" },
                { "CloseTime", "1672531499999" },
                { "QuoteVolume", "5922.94939000" },
                { "Count", "35" },
                { "TakerBuyVolume", "448.98000000" },
                { "TakerBuyQuoteVolume", "2319.58307000" },
                { "Ignore", "0" }
            };

            candleStickDataWriter.WriteRecord(record);

            dbSetMock.Verify(x => x.Add(It.IsAny<Candlestick>()), Times.Once);
            dbSetMock.Verify(x => x.Add(It.Is<Candlestick>(c =>
                c.OpenTime == 1672531200000 &&
                c.Open == 5.16700000 &&
                c.High == 5.17100000 &&
                c.Low == 5.16300000 &&
                c.Close == 5.16500000 &&
                c.Volume == 1146.43000000 &&
                c.QuoteVolume == 5922.94939000 &&
                c.Count == 35 &&
                c.TakerBuyVolume == 448.98000000 &&
                c.TakerBuyQuoteVolume == 2319.58307000 &&
                c.Ignore == 0)), Times.Once);
            dbContextMock.Verify(x => x.SaveChanges(), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(AutoMapperMappingException))]
        public void WriteRecord_ThrowsException_WhenInvalidRecord()
        {
            var dbContextMock = new Mock<ICandleStickDbContext>();
            var dbSetMock = new Mock<DbSet<Candlestick>>();
            dbContextMock.Setup(x => x.CandleStickData).Returns(dbSetMock.Object);

            var candleStickDataWriter = new DbManager(dbContextMock.Object);

            var invalidRecord = new Dictionary<string, string>
            {
                { "OpenTime", "1672531200000" }
                // Other fields are missing
            };

            candleStickDataWriter.WriteRecord(invalidRecord); // Should throw AutoMapperMappingException
        }
    }
}
