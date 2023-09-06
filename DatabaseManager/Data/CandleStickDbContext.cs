using DatabaseManager.Models;
using System.Data.Entity;

namespace DatabaseManager.Data
{
    public class CandleStickDbContext : DbContext, ICandleStickDbContext
    {
        public CandleStickDbContext() : base("BinanceDbConnectionString")
        {
        }

        public DbSet<Candlestick> CandleStickData { get; set; }
    }
}
