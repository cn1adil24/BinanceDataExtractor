using DatabaseManager.Models;
using System.Data.Entity;

namespace DatabaseManager.Data
{
    public interface ICandleStickDbContext
    {
        DbSet<Candlestick> CandleStickData { get; set; }
        int SaveChanges();
    }
}
