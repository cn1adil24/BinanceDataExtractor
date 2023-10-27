using AutoMapper;
using DatabaseManager.Data;
using DatabaseManager.Models;
using System.Collections.Generic;

namespace DatabaseManager
{
    public class DatabaseWriter
    {
        private readonly ICandleStickDbContext _dbContext;

        public DatabaseWriter(ICandleStickDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void WriteRecord(Dictionary<string, string> record)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<CandleStickMappingProfile>());

            IMapper mapper = config.CreateMapper();

            var candleStickRecord = mapper.Map<Dictionary<string, string>, Candlestick>(record);
            _dbContext.CandleStickData.Add(candleStickRecord);
            _dbContext.SaveChanges();
        }

        public void WriteAll(IEnumerable<Dictionary<string, string>> records)
        {
            var candleStickList = new List<Candlestick>();

            var config = new MapperConfiguration(cfg => cfg.AddProfile<CandleStickMappingProfile>());
            IMapper mapper = config.CreateMapper();

            foreach (var record in records)
            {
                var candleStickRecord = mapper.Map<Dictionary<string, string>, Candlestick>(record);
                candleStickList.Add(candleStickRecord);
            }

            _dbContext.CandleStickData.AddRange(candleStickList);
            _dbContext.SaveChanges();
        }
    }
}
