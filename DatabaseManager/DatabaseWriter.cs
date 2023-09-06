using AutoMapper;
using DatabaseManager.Data;
using DatabaseManager.Models;
using System.Collections.Generic;

namespace DatabaseManager
{
    public class DatabaseWriter
    {
        public void WriteRecord(Dictionary<string, string> record)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());

            IMapper mapper = config.CreateMapper();

            using (var dbContext = new CandleStickDbContext())
            {
                var candleStickRecord = mapper.Map<Dictionary<string, string>, Candlestick>(record);
                dbContext.CandleStickData.Add(candleStickRecord);
                dbContext.SaveChanges();
            }
        }
    }
}
