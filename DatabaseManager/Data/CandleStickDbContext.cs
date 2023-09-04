using DatabaseManager.Models;
using System.Data.Entity;

namespace DatabaseManager.Data
{
    internal class CandleStickDbContext : DbContext
    {
        public CandleStickDbContext() : base("BinanceDbConnectionString")
        {
        }

        public DbSet<Candlestick> CandleStickData { get; set; }
    }
}
