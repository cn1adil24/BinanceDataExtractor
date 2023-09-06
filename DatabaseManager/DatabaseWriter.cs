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
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());

            IMapper mapper = config.CreateMapper();

            var candleStickRecord = mapper.Map<Dictionary<string, string>, Candlestick>(record);
            _dbContext.CandleStickData.Add(candleStickRecord);
            _dbContext.SaveChanges();
        }
    }
}
